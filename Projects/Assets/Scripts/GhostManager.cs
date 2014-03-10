using UnityEngine;
using System.Collections;

public class GhostManager : MonoBehaviour {

	public Transform[] ghosts = new Transform[4];
	Vector2[] directionArray = new Vector2[4];
	public Transform player;
	float chaseTime = 20;
	float scatterTime = 7;
	float frightenedTime = 6;
	Vector2 PlayerLocation;
	Vector2 PreviousPlayerLocation;

	enum GhostState
	{
		Chase,
		Scatter,
		Frightened,
		Home
	};
	
	GhostState state = new GhostState ();
	GhostState previousState = new GhostState();
	
	float StateTimer = 0;

	// Use this for initialization
	void Start () {
		directionArray [0] = new Vector2 (0, 1);
		directionArray [1] = new Vector2 (-1, 0);
		directionArray [2] = new Vector2 (0, -1);
		directionArray [3] = new Vector2 (1, 0);
		state = GhostState.Scatter;
	}
	
	// Update is called once per frame
	void Update () {
		StateTimer += Time.deltaTime;
		//print (StateTimer);
		print (state);

		Vector2 roughLoc = new Vector2 ((float)Mathf.RoundToInt((float)(player.transform.position.x + 0.5)), (float)Mathf.RoundToInt((float)(player.transform.position.z + 0.5)));

		if (PlayerLocation != roughLoc) 
		{
			PreviousPlayerLocation = PlayerLocation;
		}

		for (int i = 0; i < ghosts.Length; i++)
		{
			GetTarget (ghosts[i]);
		}
		switch (state) 
		{
		case GhostState.Chase:
			if (StateTimer >= chaseTime)
			{
				StateTimer -= chaseTime;
				state = GhostState.Scatter;
				previousState = GhostState.Scatter;
			}
			return;
		case GhostState.Scatter:
			if (StateTimer >= scatterTime)
			{
				StateTimer -= scatterTime;
				state = GhostState.Chase;
				previousState = GhostState.Chase;
			}
			return;
		case GhostState.Frightened:
			if (StateTimer >= frightenedTime)
			{
				StateTimer -= frightenedTime;
				state = previousState;
			}
			return;
		case GhostState.Home:
			return;
		};
	}

	public void SetScatterPoints (int width, int height)
	{
		ghosts [0].GetComponent<Ghost> ().ScatterPoint = new Vector2 (width, height);
		ghosts [1].GetComponent<Ghost> ().ScatterPoint = new Vector2 (0, height);
		ghosts [2].GetComponent<Ghost> ().ScatterPoint = new Vector2 (width, 0);
		ghosts [3].GetComponent<Ghost> ().ScatterPoint = new Vector2 (0, 0);
	}

	void GetTarget (Transform ghost)
	{
		Vector2 target = Vector2.zero;
		Vector3 pos = ghost.transform.position;
		bool[] directions = new bool[4];

		for (int i = 0; i < directions.Length; i++)
		{
			int kindOfTile = GetComponent<LevelHandlerScript>().GetPositionInfo(pos.x + directionArray[i].x, pos.z + directionArray[i].y);
			if ( kindOfTile != 0 && kindOfTile != 2)
			{
				directions[i] = true;
			}
			else
			{
				directions[i] = false;
			}
		}
		//print (directions[0] + " " + directions[1] + " " + directions[2] + " " + directions[3]);

		if (state == GhostState.Chase) 
		{
			target = ghost.GetComponent<Ghost> ().GetChaseTarget (PlayerLocation, PreviousPlayerLocation);
		}
		else if (state == GhostState.Scatter)
		{
			target = ghost.GetComponent<Ghost> ().ScatterPoint;
		}

		ghost.GetComponent<Ghost> ().Targeting (directions, target);
	}
}
