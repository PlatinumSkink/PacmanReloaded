using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {

	public Transform player;
	public Transform level;

	string life = "info";
	string points = "";
	string jumps = "";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		points = "Points: " + player.GetComponent<PlayerScript> ().Points;
		life = "Lives: " + player.GetComponent<PlayerScript> ().Lives;
		jumps = "Jumps: " + player.GetComponent<CameraMovement> ().jumpsRemaining;
	}

	void OnGUI()
	{
		GUI.Label (new Rect (25, 25, 100, 30 * points.Length), points);
		GUI.Label (new Rect (25, 50, 100, 30 * life.Length), life);
		GUI.Label (new Rect (25, 75, 100, 30 * jumps.Length), jumps);
	}
}
