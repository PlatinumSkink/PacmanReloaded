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

	public void PlaceCandy(float d, float mD){
		Vector3 candyPosition = transform.position;
		candyPrefab = GameObject.Find ("LevelHandler").GetComponent<PrefabManager>().FindPrefab("X_CandyPrefab");
		candyPosition.y += .5f;
		print(candyPrefab);
		if(d < dF * mD){
			Transform candy = (Transform) Instantiate(candyPrefab, candyPosition,Quaternion.identity);
			candy.parent = transform;
		}
	}
}
