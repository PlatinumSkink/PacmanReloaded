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
	public bool pause = false;

	//Four states. Chase follows Pac-Man. Scatter pursues each ghost's scatter point in the corners.
	//Frightened goes randomly when Pac-Man has eaten a SuperSemla. Home runs around in the home or back to it when the ghost has been eaten.
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
		if (pause == false) 
		{
			StateCheck();
		}
	}
	void StateCheck ()
	{
		StateTimer += Time.deltaTime;

		Vector2 roughLoc = new Vector2 ((float)Mathf.RoundToInt((float)(player.transform.position.x)), (float)Mathf.RoundToInt((float)(player.transform.position.z)));

		//I did not know how to find out which direction the player is looking, so I used the previous square the player was standing on and assumed he looked in the opposite direction.
		if (PlayerLocation != roughLoc) 
		{
			PreviousPlayerLocation = PlayerLocation;
			PlayerLocation = roughLoc;
		}

		for (int i = 0; i < ghosts.Length; i++)
		{
			GetTarget (ghosts[i]);
			ghosts[i].BroadcastMessage("GhostUpdate");
		}

		//Three out of four states operate on a timer which the state will end upon the timer going over a value.
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

	//Each ghost has his or her scatter point in a different corner. This code is accessed from SetLevel in LevelHandler when the level is created with the individual width and height of each level.
	public void SetScatterPoints (int width, int height)
	{
		ghosts [0].GetComponent<Ghost> ().ScatterPoint = new Vector2 (width, height);
		ghosts [1].GetComponent<Ghost> ().ScatterPoint = new Vector2 (0, height);
		ghosts [2].GetComponent<Ghost> ().ScatterPoint = new Vector2 (width, 0);
		ghosts [3].GetComponent<Ghost> ().ScatterPoint = new Vector2 (0, 0);
	}

	//This is the code which tells each ghost to find what target square they're aiming for.
	void GetTarget (Transform ghost)
	{
		Vector2 target = Vector2.zero;
		Vector3 pos = ghost.transform.position;
		bool[] directions = new bool[4];

		//For each direction, marked in the directionArray, it examines what kind of tile it is. As long as it isn't empty space (0) or a wall (2), the ghosts can move over it.
		for (int i = 0; i < directions.Length; i++)
		{
			int kindOfTile = GetComponent<LevelHandlerScript>().GetPositionInfo(pos.x + directionArray[i].x, pos.z + directionArray[i].y);
			if (kindOfTile != 0 && kindOfTile != 2)
			{
				directions[i] = true;
			}
			else
			{
				directions[i] = false;
			}
		}

		//Depending on the state, the ghosts will go for different targets. Here is where this is determined.
		if (state == GhostState.Chase) 
		{
			target = ghost.GetComponent<Ghost> ().GetChaseTarget (PlayerLocation, PreviousPlayerLocation);
			//target = ghost.GetComponent<Ghost> ().ScatterPoint;
		}
		else if (state == GhostState.Scatter)
		{
			target = ghost.GetComponent<Ghost> ().ScatterPoint;
			//target = ghost.GetComponent<Ghost> ().GetChaseTarget (PlayerLocation, PreviousPlayerLocation);
		}

		//Finally, send the obtained target and available directions to the ghosts so they can decide where they want to go.
		ghost.GetComponent<Ghost> ().Targeting (directions, target);
	}

	//At the pause command, all music will be terminated and pause will turn true. This should stop movement.
	public void Pause()
	{
		pause = true;
		for (int i = 0; i < ghosts.Length; i++)
		{
			ghosts[i].audio.Stop();
		}
	}
}
