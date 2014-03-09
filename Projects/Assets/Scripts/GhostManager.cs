using UnityEngine;
using System.Collections;

public class GhostManager : MonoBehaviour {

	public Transform[] ghosts = new Transform[4];
	Vector2[] directionArray = new Vector2[4];
	public Transform player;

	// Use this for initialization
	void Start () {
		directionArray [0] = new Vector2 (0, 1);
		directionArray [1] = new Vector2 (-1, 0);
		directionArray [2] = new Vector2 (0, -1);
		directionArray [3] = new Vector2 (1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		GetTarget (ghosts[0]);
	}

	void GetTarget (Transform ghost)
	{
		Vector3 pos = ghost.transform.position;
		bool[] directions = new bool[4];

		for (int i = 0; i < directions.Length; i++)
		{
			if (GetComponent<LevelHandlerScript>().GetPositionInfo(pos.x + directionArray[i].x, pos.z + directionArray[i].y) == 1)
			{
				directions[i] = true;
			}
			else
			{
				directions[i] = false;
			}
		}
		print (directions[0] + " " + directions[1] + " " + directions[2] + " " + directions[3]);
		ghost.GetComponent<Ghost> ().Targeting (directions, new Vector2(player.transform.position.x, player.transform.position.z));
	}
}
