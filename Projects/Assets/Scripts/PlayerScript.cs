using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	
	public int Points = 0;
	public int Lives = 3;
	int PointMeasurer = 0;
	public int PointLimit = 10000;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < -10){
			OnDeath();
		}
	}

	int AteNormalCandy ()
	{
		Points += 10;
		PointMeasurer += 10;
		if (PointMeasurer >= PointLimit) 
		{
			PointMeasurer -= PointLimit;
			Lives++;
		}
		return Points;
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.CompareTag("Ghost") ){
			print (this.name + " bumped into a ghost");
		}
	}

	void OnDeath(){
		Lives--;
		//GameObject.Find("3_StartPrefab").GetComponent<Initializer>().PlacePlayer();

	}
}
