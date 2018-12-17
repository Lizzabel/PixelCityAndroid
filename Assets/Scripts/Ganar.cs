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
        PlayerPrefs.SetInt("Nivel" + numeroNivel + "_score", PuntosVida.puntos);
		MenuNivelCompletado.SetActive(false);
		PlayerPrefs.Save();
    }

	private void OnTriggerEnter2D(Collider2D Trigger)
	{
		if (Trigger.gameObject.tag == "Player")
		{
			MenuNivelCompletado.SetActive(true);
            GanarPuntos();
            Time.timeScale = 0f;
        }
	}
       
    public void GanarPuntos()
    {
        PlayerPrefs.SetInt("Nivel" + (numeroNivel + 1), 1);
        PuntosText.text = PuntosVida.puntos.ToString();
        PlayerPrefs.SetInt("Nivel" + numeroNivel + "_score", PuntosVida.puntos);
		PlayerPrefs.Save();
    }
	public void SiguienteNivel()
	{
		Time.timeScale = 1f;
		if (numeroNivel == 1)
		{
			Initiate.Fade("Nivel2",Color.black, 1.0f);
		}
		else if (numeroNivel == 2)
		{
			Initiate.Fade("Nivel3", Color.black, 1.0f);
		} 
		else if(numeroNivel == 3)
		{
			Initiate.Fade("Nivel4", Color.black, 1.0f);
		}
		else
		{
			Initiate.Fade("Menu", Color.black, 1.0f);
		}
	}
}
