using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	int Lives = 3;
	int Points = 0;
	int PointMeasurer = 0;
	int ExtraLifeLimit = 10000;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	int AddPoints (int points)
	{
		Points += points;
		PointMeasurer += points;
		if (PointMeasurer >= ExtraLifeLimit) 
		{
			Lives += 1;
			PointMeasurer -= ExtraLifeLimit;
		}
		return Points;
	}

	bool Killed ()
	{
		Lives -= 1;
		if (Lives <= 0) 
		{
			return true;
		}
		return false;
	}
}
