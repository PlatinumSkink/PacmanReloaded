using UnityEngine;
using System.Collections;

public class GameOverCameraScript : MonoBehaviour {
	private Vector3 endPos;
	private Vector3 pacManPos;
	private float lerp;
	private bool useGameOverCamera;
	// Use this for initialization
	void Start () {
		lerp = 0.05f;
		useGameOverCamera = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.X)) {
			useGameOverCamera = !useGameOverCamera;
		}

		if(useGameOverCamera)
	    {
			this.camera.enabled = true;
			GameObject levelHandler = GameObject.Find ("LevelHandler");
			LevelHandlerScript script = levelHandler.GetComponent<LevelHandlerScript> ();
			GameObject PacMan = GameObject.Find ("Player");
			pacManPos = PacMan.transform.position;

			// Find the level's centerpoint
			int width = script.GetLevelWidth ();
			int depth = script.GetLevelDepth ();
			endPos = new Vector3 (width / 2, 20, depth / 2);
			this.transform.position = Vector3.Lerp (pacManPos, endPos, lerp);
			this.transform.rotation = Quaternion.LookRotation(Vector3.down);
			if(lerp <= 1.0f)
			{
				lerp += 0.05f;
			}
		}
	
	}
}
