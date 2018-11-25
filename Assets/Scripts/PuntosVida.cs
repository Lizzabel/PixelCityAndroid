using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntosVida : MonoBehaviour {

	public static int vida;
	public static int puntos;

	public Text PuntosText;

	private void Awake()
	{
		vida = 100;
		puntos = 0;
	}

	private void Start()
	{
        StartCoroutine(Esperar());
	}

	public void Salud()
	{
		//PuntosText.text = puntos.ToString();
		Debug.Log("falta configurar los corazones");
	}

	public void Puntaje()
	{
		PuntosText.text = puntos.ToString();
	}

	IEnumerator Esperar()
	{
		if (BrayanPropiedades.Atacando)
		{
			Salud(); // cambiar esto por vida...
        }
		if (ArepaFlotante.ContarArepa)
		{
			Puntaje();
			ArepaFlotante.ContarArepa = false;
		}
		yield return new WaitForSecondsRealtime(0.5f);
		StartCoroutine(Esperar());
	}
}
