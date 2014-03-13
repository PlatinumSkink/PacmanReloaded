using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HauntScript : MonoBehaviour {

	GameObject[] ghosts;

	// Use this for initialization
	void Start () {
		ghosts = GameObject.FindGameObjectsWithTag("Ghost");
		PlaceGhosts();
	}
	
	// Update is called once per frame
	void Update () {

	}

void PlaceGhosts(){
	foreach (GameObject g in ghosts){
		g.transform.position = transform.position + new Vector3(0,.5f, 0);
	}
	}
}
