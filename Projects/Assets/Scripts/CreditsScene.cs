﻿using UnityEngine;
using System.Collections;

public class CreditsScene : MonoBehaviour {

	string devs = "Developers:\nCalle Anden\nJens Lomander\nMarcus Wallman\nMartin Lundgren\nNiklas Cullberg";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//This code creates text which shows our names and a button with which to return to the main menu.
	void OnGUI(){
		GUI.Label (new Rect (25, 25, 100, 30 * devs.Length), devs);

		if (GUI.Button (new Rect (10, 230, 150, 100), "Back")) {
			SceneManager.ChangeScene("MainMenu");
		}
	}
}
