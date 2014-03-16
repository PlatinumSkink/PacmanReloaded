using UnityEngine;
using System.Collections;

public class Clyde : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Clyde will go towards the player if he is 8 tiles distance away, otherwise he'll go towards his scatter point.
	public Vector2 Chase (Vector2 player)
	{
		if (Mathf.Sqrt (Mathf.Pow (player.x - transform.position.x, 2) + Mathf.Pow (player.y - transform.position.y, 2)) > 8) 
		{
			return player;
		} 
		else 
		{
			return GetComponent<Ghost>().ScatterPoint;
		}
	}
	
	void Scatter ()
	{
		
	}
}
