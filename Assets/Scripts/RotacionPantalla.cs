using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionPantalla : MonoBehaviour
{

	public bool Portrait;
	public bool LandScapeRight;

	private void Start()
	{
		GirarPantalla();
	}
	IEnumerator Esperar()
	{
		yield return new WaitForSecondsRealtime(2.0f);
		GirarPantalla();
		StartCoroutine(Esperar());
	}
	void GirarPantalla()
	{
		Screen.autorotateToPortrait = Portrait;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeRight = LandScapeRight;
        Screen.autorotateToLandscapeLeft = false;
	}
    
}
