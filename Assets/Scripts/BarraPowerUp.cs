using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraPowerUp : MonoBehaviour {

	float maxPower = 10f;
	float power;
	Image BarraPower;
   
	private void OnEnable()
	{
		BarraPower = gameObject.GetComponent<Image>();
		power = 10;
		BarraPower.fillAmount = power / maxPower;
		StartCoroutine(EsperarBarra());

	}
    IEnumerator EsperarBarra()
    {
		if (power > 0)
		{
			yield return new WaitForSecondsRealtime(0.5f);
            power--;
            BarraPower.fillAmount = power / maxPower;
            StartCoroutine(EsperarBarra());
		}else
		{
			gameObject.SetActive(false);
		}
    }
}
