using UnityEngine;
using System.Collections;

public class SoundObjectFile : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	}

	//Simply tell it to play. This is because one object can only hold one sound file.
	void PlayAudio()
	{
		if (audio.isPlaying == false) 
		{
			audio.Play ();
		}
	}
}
