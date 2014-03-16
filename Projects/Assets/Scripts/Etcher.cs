using UnityEngine;
using System.Collections;

public class Etcher : MonoBehaviour {
	
	public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//The Etcher is a class which etches an object onto another object without being its child. If the object disappears the etcher is destroyed. 
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
