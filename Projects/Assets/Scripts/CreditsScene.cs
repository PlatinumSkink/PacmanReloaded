using UnityEngine;
using System.Collections;

public class CreditsScene : MonoBehaviour {

	string devs = "Developers:\nCalle Anden\nJens Lomander\nMarcus Wallman\nMartin Lundgren\nNiklas Cullberg";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.Label (new Rect (25, 25, 100, 30 * devs.Length), devs);
		}
}
