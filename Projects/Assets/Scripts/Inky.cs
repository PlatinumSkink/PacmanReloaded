using UnityEngine;
using System.Collections;

public class Inky : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Vector2 Chase (Vector2 playerLoc, Vector2 prevPlayerLoc)
	{
		Vector2 distance = new Vector2 (prevPlayerLoc.x - playerLoc.x, prevPlayerLoc.y - playerLoc.y);
		return new Vector2(playerLoc.x - distance.x * 4, playerLoc.y - distance.y * 4);
	}
	
	void Scatter ()
	{
		
	}
}
