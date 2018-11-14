using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionPantalla : MonoBehaviour {

	public bool Portrait;
	public bool LandScapeRight;

	void Awake()
	{
		Screen.autorotateToPortrait = Portrait;
        Screen.autorotateToPortraitUpsideDown = false;
		Screen.autorotateToLandscapeRight = LandScapeRight;
        Screen.autorotateToLandscapeLeft = false;
	}
}
