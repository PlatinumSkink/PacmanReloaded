using UnityEngine;
using System.Collections;

public class Initializer : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		player.transform.position = transform.position + new Vector3(0,6,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
