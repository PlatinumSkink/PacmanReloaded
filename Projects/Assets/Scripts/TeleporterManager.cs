using UnityEngine;
using System.IO;
using System.Collections;

public static class TeleporterManager : object {

	static TeleporterScript greenTeleporterScript;
	static int greenTeleporterCount = 0;

	public static void AddTeleporter(int teleporterType, Transform tile, Transform player, LevelHandlerScript levelHandlerScript)
	{
		// green teleporter
		if (teleporterType == 4) {
			greenTeleporterCount++;
			if (greenTeleporterCount == 1) {
				TeleporterScript script = tile.GetComponent<TeleporterScript> ();
				greenTeleporterScript = script; // When adding the second teleporter, this reference is needed.
				script.teleportTo = new Vector3(); // The real location of the other teleporter is not known yet.
				script.teleporterType = teleporterType;
				script.player = player;
				script.levelHandlerScript = levelHandlerScript;
			} else if (greenTeleporterCount == 2) {
				TeleporterScript script = tile.GetComponent<TeleporterScript> ();
				script.teleportTo = FindTeleporterDesination (greenTeleporterScript.transform.position, levelHandlerScript);			
				script.teleporterType = teleporterType;
				script.player = player;
				script.levelHandlerScript = levelHandlerScript;			

				// Now the destination for the first teleporter can be set.
				greenTeleporterScript.teleportTo = FindTeleporterDesination(script.transform.position, levelHandlerScript);
			} else {
				Debug.LogError ("Error: no more than two teleporters of each color possible");
			}
		}
	}

	// This will find a tile adjecent to the teleporter that you can teleport to.
	static Vector3 FindTeleporterDesination(Vector3 teleporterLocation, LevelHandlerScript script)
	{
		Vector3 destination = teleporterLocation;
		// Right
		if (script.GetPositionInfo (destination.x + 1, destination.z) == 1) {
			destination.x +=1;
			goto end;
		}
		// Left
		if (script.GetPositionInfo (destination.x - 1, destination.z) == 1) {
			destination.x -=1;
			goto end;
		}
		// Top
		if (script.GetPositionInfo (destination.x, destination.z + 1) == 1) {
			destination.z +=1;
			goto end;
		}
		// Bottom
		if (script.GetPositionInfo (destination.x, destination.z - 1) == 1) {
			destination.z -=1;
			goto end;
		}
	end:
		destination.y += 0.5f;
		destination.x = Mathf.Floor (destination.x);
		destination.z = Mathf.Floor (destination.z);
		return destination;
	}

	// The players direction needs to be changed when the exit the teleporter - otherwise they might run headfirst into a wall!
	static Vector3 FindExitDirection(Vector3 teleporterLocation, Vector3 teleporterDesination)
	{
		Vector3 direction = teleporterLocation - teleporterDesination;
		direction.Normalize ();
		return direction;
	}
}

