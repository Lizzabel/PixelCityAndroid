using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntosVida : MonoBehaviour {

	public static float vida;
	public static int puntos;
	public GameObject barVidaObject;
	public static Image barraVida;
	public static float maxVida = 100f;

	public Text PuntosText;

	private void Awake()
	{
		vida = 100f;
		puntos = 0;
	}
    
	private void Start()
	{
        StartCoroutine(Esperar());
		barraVida = barVidaObject.GetComponent<Image>();
		PlayerPrefs.SetInt("val", 1);
		PlayerPrefs.Save();
	}

	public void Puntaje()
	{
		PuntosText.text = puntos.ToString();
	}

	IEnumerator Esperar()
	{
		if (ArepaFlotante.ContarArepa || ArepaDisparo.ContarGolpe)
		{
			Puntaje();
			ArepaFlotante.ContarArepa = false;
			ArepaDisparo.ContarGolpe = false;
		}
		yield return new WaitForSecondsRealtime(0.5f);
		StartCoroutine(Esperar());
	}
}
