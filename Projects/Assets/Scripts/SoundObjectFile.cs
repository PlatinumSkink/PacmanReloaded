using UnityEngine;
using System.Collections;

public class SoundObjectFile : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	}

	void PlayAudio()
	{
		if (audio.isPlaying == false) 
		{
			audio.Play ();
		}
	}
}
