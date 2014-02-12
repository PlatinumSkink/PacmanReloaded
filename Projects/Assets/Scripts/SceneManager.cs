using UnityEngine;
using System.Collections;

// The starting point of the game. It loads/unloads scenes.
public class SceneManager : MonoBehaviour {
	string initialScene = "Pac-Man Reloaded";

	// Use this for initialization
	void Start () {
		Application.LoadLevelAdditive (initialScene);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
