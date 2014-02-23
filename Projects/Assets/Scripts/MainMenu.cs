using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI() {
		if (GUI.Button (new Rect (10,10,150,100), "Start")) {
			SceneManager.ChangeScene("Pac-Man Reloaded");
				}
		if (GUI.Button (new Rect (10, 120, 150, 100), "Credits")) {
			SceneManager.ChangeScene("Credits");
				}
		if (GUI.Button (new Rect (10, 120, 150, 100), "Quit")) {
			Application.Quit ();
		}
	}
}
