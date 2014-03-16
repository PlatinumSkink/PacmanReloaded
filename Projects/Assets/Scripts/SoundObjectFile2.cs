using UnityEngine;
using System.Collections;

public class SoundObjectFile2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	//Because I needed two functions, one for each sound file.
	void PlayOtherAudio()
	{
		if (audio.isPlaying == false) 
		{
			audio.Play ();
		}
	}
}
