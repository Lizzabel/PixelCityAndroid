using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ganar : MonoBehaviour {

	public int numeroNivel;

	void Start()
    {
        PlayerPrefs.SetInt("Nivel" + (numeroNivel + 1), 1);
        PlayerPrefs.SetInt("Nivel" + numeroNivel + "_score", PuntosVida.puntos);
    }

	private void OnTriggerEnter2D(Collider2D Trigger)
	{
		if (Trigger.gameObject.tag == "Player")
		{
			GanarPuntos();
		}
	}
       
    public void GanarPuntos()
    {
        PlayerPrefs.SetInt("Nivel" + numeroNivel + "_score", PuntosVida.puntos);
        Initiate.Fade("Menu", Color.black, 1f);
    }
}
