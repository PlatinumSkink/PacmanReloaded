using UnityEngine;
using System.Collections;

// The starting point of the game. It loads/unloads scenes.
public class SceneManager : object {
	static string initialScene = "MainMenu";
	static string currentScene;

	// Use this for initialization
	void Start () {
		currentScene = initialScene;
		Application.LoadLevelAdditive (initialScene);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void ChangeScene(string scene){
		// This will unload the current scene and load a new scene.
		Application.LoadLevel(scene);
		currentScene = scene;
	}
}
