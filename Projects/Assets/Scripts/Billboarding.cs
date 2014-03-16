using UnityEngine;
using System.Collections;

// This class will change the rotation towards the player.
public class Billboarding : MonoBehaviour {
	public Transform player;
	public GameObject gameOverCamera;

	// Use this for initialization
	void Start () {
		gameOverCamera = GameObject.Find ("GameOverCamera");
	}
	
	// Update is called once per frame
	void Update () {
		//If GameOver, the billboard should look at the GameOver camera. Otherwise at the player.
		if (gameOverCamera.camera.enabled) {
			this.transform.LookAt (gameOverCamera.transform.position);
		} else {
			this.transform.LookAt (player.transform.position);
		}
	}
}
