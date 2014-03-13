using UnityEngine;
using System.Collections;

public class SoundObjectFile2 : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = target.transform.position;
	}
	
	void PlayOtherAudio()
	{
		if (audio.isPlaying == false) 
		{
			audio.Play ();
		}
	}
}
