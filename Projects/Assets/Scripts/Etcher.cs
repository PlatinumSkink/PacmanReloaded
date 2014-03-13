using UnityEngine;
using System.Collections;

public class Etcher : MonoBehaviour {
	
	public Transform target;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) 
		{
			this.transform.position = target.transform.position;
		}
		else 
		{
			Destroy(gameObject);
		}
	}
}
