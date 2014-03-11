using UnityEngine;
using System.Collections;

public class Pinky : MonoBehaviour {

	public Transform Blinky;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Vector2 Chase (Vector2 playerLoc, Vector2 prevPlayerLoc)
	{
		Vector2 distance = new Vector2 (prevPlayerLoc.x - playerLoc.x, prevPlayerLoc.y - playerLoc.y);
		Vector2 ahead = new Vector2(playerLoc.x - distance.x * 2, playerLoc.y - distance.y * 2);
		Vector2 BlinkyPos = new Vector2 (Blinky.position.x, Blinky.position.z);
		distance = new Vector2 (BlinkyPos.x - ahead.x, BlinkyPos.y - ahead.y);
		return new Vector2(ahead.x - distance.x, ahead.y - distance.y);
	}

	void Scatter ()
	{
		
	}
}
