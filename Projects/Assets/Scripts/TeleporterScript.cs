using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeleporterScript : MonoBehaviour {
	// The location that the teleporter teleports to.
	// This location is *not* the location of the other teleporter, but instead a tile nearby.
	// TeleporterManager finds a suitable location.
	public Vector3 teleportTo;
	public int teleporterType;
	public LevelHandlerScript levelHandlerScript;
	public Transform player;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int x = levelHandlerScript.GetPositionInfo (player.transform.position);
		if (x == teleporterType) {
			player.transform.position = teleportTo;
		}
	}
}
