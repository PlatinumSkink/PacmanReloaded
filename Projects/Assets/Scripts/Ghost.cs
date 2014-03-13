using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour {

	public string Name = "Blinky";
	public float speed = 0.05f;
	Vector2 direction = new Vector2(0, 1);
	int currentDirection = 0;
	Vector3 pos;
	float moveCheck = 0;
	bool move = false;
	public Vector2 ScatterPoint = new Vector2(0, 0);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		pos = gameObject.transform.position;
		pos.x += direction.x * speed;
		pos.z += direction.y * speed;
		gameObject.transform.position = pos;
		moveCheck += speed;
		if (moveCheck >= 1) 
		{
			move = true;
			moveCheck -= 1;
		}
	}

	public Vector2 GetChaseTarget (Vector2 playerLoc, Vector2 prevPlayerLoc)
	{
		Vector2 target = Vector2.zero;
		if (GetComponent<Blinky> () != null) 
		{
			target = GetComponent<Blinky>().Chase(playerLoc);
		}
		else if (GetComponent<Inky> () != null) 
		{
			target = GetComponent<Inky>().Chase(playerLoc, prevPlayerLoc);
		}
		else if (GetComponent<Pinky> () != null) 
		{
			target = GetComponent<Pinky>().Chase(playerLoc, prevPlayerLoc);
		}
		else if (GetComponent<Clyde> () != null) 
		{
			target = GetComponent<Clyde>().Chase(playerLoc);
		}
		return target;
	}

	// The two ints is the square the ghost is targeting. 
	//The array of bools is in the order (0=up, 1=left, 2=down, 3=right). True means the ghost can go in that direction.
	public void Targeting (bool[] directions, Vector2 target)
	{
		if (move == true) 
		{
			move = false;
			float[] distances = new float[4];
			for (int i = 0; i < distances.Length; i++) 
			{
				distances [i] = 1000000000000;
			}

			bool FoundDirection = false;

			//Calculates the Eucledian distance from each available direction.
			if (directions [0] == true && currentDirection != 2) 
			{
				distances [0] = Mathf.Sqrt (Mathf.Pow ((float)(gameObject.transform.position.x - target.x), 2.0f) + Mathf.Pow ((float)((gameObject.transform.position.z + 1) - target.y), 2.0f));
				FoundDirection = true;
			} 
			if (directions [1] == true && currentDirection != 3) 
			{
				distances [1] = Mathf.Sqrt (Mathf.Pow ((float)((gameObject.transform.position.x - 1) - target.x), 2.0f) + Mathf.Pow ((float)(gameObject.transform.position.z - target.y), 2.0f));
				FoundDirection = true;
			} 
			if (directions [2] == true && currentDirection != 0) 
			{
				distances [2] = Mathf.Sqrt (Mathf.Pow ((float)(gameObject.transform.position.x - target.x), 2.0f) + Mathf.Pow ((float)((gameObject.transform.position.z - 1) - target.y), 2.0f));
				FoundDirection = true;
			} 
			if (directions [3] == true && currentDirection != 1) 
			{
				distances [3] = Mathf.Sqrt (Mathf.Pow ((float)((gameObject.transform.position.x + 1) - target.x), 2.0f) + Mathf.Pow ((float)(gameObject.transform.position.z - target.y), 2.0f));
				FoundDirection = true;
			} 
			 
			if (FoundDirection == false)
			{
				Reverse();
				return;
			}

			//Afterwards, compare which is the shortest.
			int shortest = 0;

			for (int i = 0; i < distances.Length; i++) 
			{
				if (distances [i] < distances [shortest]) 
				{
					shortest = i;
				}
			}
			//print (shortest + " is shortest.");

			currentDirection = shortest;

			SetDirection();
		}
	}

	public void Reverse ()
	{
		currentDirection += 2;
		if (currentDirection > 3) 
		{
			currentDirection -= 4;
		}
		SetDirection ();
	}

	void SetDirection ()
	{
		if (currentDirection == 0) 
		{
			direction = new Vector2 (0, 1);
		} 
		else if (currentDirection == 1) 
		{
			direction = new Vector2 (-1, 0);
		} 
		else if (currentDirection == 2) 
		{
			direction = new Vector2 (0, -1);
		} 
		else if (currentDirection == 3) 
		{
			direction = new Vector2 (1, 0);
		}
	}
}