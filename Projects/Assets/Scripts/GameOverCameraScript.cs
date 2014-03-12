using UnityEngine;
using System.Collections;

public class GameOverCameraScript : MonoBehaviour {
	private Vector3 endPos;
	private Vector3 pacManPos;
	private float lerp;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.X)) {
			this.camera.enabled = true;
			lerp = 0.0f;
		}

		if (Input.GetKeyDown (KeyCode.Z)) {
			this.camera.enabled = false;
		}

		if(this.camera.enabled)
	    {
			GameObject levelHandler = GameObject.Find ("LevelHandler");
			LevelHandlerScript script = levelHandler.GetComponent<LevelHandlerScript> ();
			GameObject PacMan = GameObject.Find ("Player");
			pacManPos = PacMan.transform.position;

			// Find the level's centerpoint
			int width = script.GetLevelWidth ();
			int depth = script.GetLevelDepth ();
			int height = width > depth ? width : depth; // Set the height so that the entire map will be visible when you look down.
			endPos = new Vector3 (width / 2, height, depth / 2);
			this.transform.position = Vector3.Lerp (pacManPos, endPos, lerp);
			this.transform.rotation = Quaternion.LookRotation(Vector3.down);
			if(lerp <= 1.0f)
			{
				lerp += 0.01f;
			}
		}
	
	}
}
