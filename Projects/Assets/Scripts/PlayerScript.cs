using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	
	// Static references created in the Unity Editor
	// http://answers.unity3d.com/questions/7555/how-do-i-call-a-function-in-another-gameobjects-sc.html
	public GameObject levelHandler;
	public Transform player;
	// ... Vad är detta ovan?

	public int Points = 0;
	public int Lives = 3;
	int PointMeasurer = 0;
	public int PointLimit = 10000;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void AteNormalCandy ()
	{
		AteCandy (10);
		BroadcastMessage ("PlayAudio");
	}

	void AteSuperSemla ()
	{
		AteCandy (50);
		GetComponent<CameraMovement> ().jumpsRemaining += 2;
		BroadcastMessage ("PlayOtherAudio");
	}

	void AteCandy (int points)
	{
		Points += points;
		PointMeasurer += points;
		levelHandler.GetComponent<LevelHandlerScript>().candies--;
		if (PointMeasurer >= PointLimit) 
		{
			PointMeasurer -= PointLimit;
			Lives++;
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.CompareTag("Ghost") ){
			//  print (this.name + " bumped into a ghost");
			GameObject gameOverCamera = GameObject.Find("GameOverCamera");
			Camera camera =gameOverCamera.GetComponent<Camera>();
			gameOverCamera.BroadcastMessage("GameOver");
			levelHandler.GetComponent<GhostManager>().pause = true;
		}
	}
}
