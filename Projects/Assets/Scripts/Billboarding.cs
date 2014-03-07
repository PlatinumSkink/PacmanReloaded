using UnityEngine;
using System.Collections;

// This class will change the rotation towards the player.
public class Billboarding : MonoBehaviour {
	public Transform player;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		this.transform.LookAt (player.transform.position);
	}
}
