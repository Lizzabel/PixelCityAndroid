using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionPantalla : MonoBehaviour
{

	public int nivelToRotate;

	private void Start()
	{
		GirarPantalla();
	}
	IEnumerator Esperar()
	{
		yield return new WaitForSecondsRealtime(0.5f);
		GirarPantalla();
		StartCoroutine(Esperar());
	}
	void GirarPantalla()
	{
		if (nivelToRotate == 0)
		{
			Screen.autorotateToPortrait = true;
            Screen.autorotateToPortraitUpsideDown = false;
			Screen.autorotateToLandscapeRight = false;
            Screen.autorotateToLandscapeLeft = false;
			Screen.orientation = ScreenOrientation.Portrait;
		}else
		{
			Screen.autorotateToPortrait = false;
            Screen.autorotateToPortraitUpsideDown = false;
			Screen.autorotateToLandscapeRight = true;
            Screen.autorotateToLandscapeLeft = false;
			Screen.orientation = ScreenOrientation.LandscapeRight;
		}

        
	}
    
}
