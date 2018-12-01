using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ganar : MonoBehaviour {

	public int numeroNivel;
	public GameObject MenuNivelCompletado;
	public Text PuntosText;

	void Start()
    {
        PlayerPrefs.SetInt("Nivel" + (numeroNivel + 1), 1);
        PlayerPrefs.SetInt("Nivel" + numeroNivel + "_score", PuntosVida.puntos);
		MenuNivelCompletado.SetActive(false);
    }

	private void OnTriggerEnter2D(Collider2D Trigger)
	{
		if (Trigger.gameObject.tag == "Player")
		{
			MenuNivelCompletado.SetActive(true);
			GanarPuntos();
		}
	}
       
    public void GanarPuntos()
    {
		PuntosText.text = PuntosVida.puntos.ToString();
        PlayerPrefs.SetInt("Nivel" + numeroNivel + "_score", PuntosVida.puntos);
    }
}
