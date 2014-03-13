using UnityEngine;
using System.Collections;

public class SoundObjectFile : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		this.transform.position = target.transform.position;
	}

	void PlayAudio()
	{
		if (audio.isPlaying == false) 
		{
			audio.Play ();
		}
	}
}
