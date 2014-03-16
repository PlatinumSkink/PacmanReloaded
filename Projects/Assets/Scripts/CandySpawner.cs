using UnityEngine;
using System.Collections;

public class CandySpawner : MonoBehaviour {

	Transform candyPrefab;
	public float dF = 0.5f;

	// Use this for initialization
	void Start () {
		}
	
	// Update is called once per frame
	void Update () {
	
	}

	//The tile will generate a candy above it assuming some variables.
	public void PlaceCandy(float d, float mD, Transform prefab){
		Vector3 candyPosition = transform.position;
		//candyPrefab = GameObject.Find ("LevelHandler").GetComponent<PrefabManager>().FindPrefab("X_CandyPrefab");
		candyPrefab = prefab;
		candyPosition.y += .5f;
		//print(candyPrefab);
		if(d < dF * mD){
			Transform candy = (Transform) Instantiate(candyPrefab, candyPosition,Quaternion.identity);
			candy.parent = transform;
		}
	}

	//Upon contact between the tile and the player, the candy will be considered eaten and the message will be sent to the player while the candy is destroyed.
	void OnTriggerEnter(Collider other)
	{
		Component CandyScript;
		CandyScript = GetComponentInChildren<Candy>();
		if (CandyScript != null) {
			if (other.gameObject.tag == "MainCamera") {
				other.gameObject.BroadcastMessage ("AteNormalCandy");
				CandyScript.BroadcastMessage("Destroy");
			}
		}
	}
}
