using UnityEngine;
using System.Collections;

public class SuperSemla : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Upon contact with the player it destroys itself and sends a message of having been eaten to the player.
	void OnTriggerEnter(Collider other)
	{
		Component playerScript = other.GetComponent<PlayerScript> ();
		if (playerScript != null)
		{
			playerScript.BroadcastMessage("AteSuperSemla");
			Destroy(gameObject);
		}
	}
}
