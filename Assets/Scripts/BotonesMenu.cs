using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotonesMenu : MonoBehaviour {

    public Color colorEscena;
    public string nombreEscena;
    public float tiempoEscena;
    public GameObject panelMenu;
    public GameObject panelNiveles;
    public GameObject panelOpciones;
   
    public GameObject botonVolumen;
    Image imgVolumen;
    //int numeroMute = 1;
    public Sprite[] muted;

	int val;
	public int numeroNivel;

    AudioSource[] audios;
    public GameObject[] objAudios;
       
    private void Start()
    {
        imgVolumen = botonVolumen.GetComponent<Image>();
        imgVolumen.sprite = muted[0];


		audios = new AudioSource[objAudios.Length];

        for (int i = 0; i < objAudios.Length; i++)
        {
            audios[i] = objAudios[i].GetComponent<AudioSource>();
        }

        
		val = PlayerPrefs.GetInt("val");
		Debug.Log(val);
		if (val == 0)
		{
			PlayerPrefs.SetInt("MusicaOn", 1);
			PlayerPrefs.SetInt("Nivel" + (numeroNivel + 1), 1);
            PlayerPrefs.SetInt("Nivel" + numeroNivel + "_score", PuntosVida.puntos);
			PlayerPrefs.Save();

		}

		if (PlayerPrefs.GetInt("MusicaOn") == 0)
        {
            for (int i = 0; i < objAudios.Length; i++)
            {
                audios[i].volume = 0f;
                imgVolumen.sprite = muted[1];
            }
        }
        else
        {
            for (int i = 0; i < objAudios.Length; i++)
            {
				audios[i].volume = 0.3f;
                audios[0].volume = 1f;
                imgVolumen.sprite = muted[0];
            }
        }
        PlayerPrefs.Save();

    }
    public void Jugar()
    {
        Initiate.Fade(nombreEscena, colorEscena, tiempoEscena);
    }

    public void ActivarMenuPrincipal()
    {
        panelMenu.SetActive(true);
        panelNiveles.SetActive(false);
        panelOpciones.SetActive(false);
    }

    public void ActivarMenuNiveles()
    {
        panelMenu.SetActive(false);
        panelNiveles.SetActive(true);
        panelOpciones.SetActive(false);
    }

    public void ActivarMenuOpciones()
    {
        panelMenu.SetActive(false);
        panelNiveles.SetActive(false);
        panelOpciones.SetActive(true);
    }

	public void MutearLosAudios()
    {
        /*
    if (elAudio.enabled == false)
    {
        elAudio.enabled = true;
        PlayerPrefs.SetInt("MusicaOn", 1);
    }
    else
    {
        elAudio.enabled = false;
        PlayerPrefs.SetInt("MusicaOn", 0);
    }
    */
        if (PlayerPrefs.GetInt("MusicaOn") == 0)
        {
            for (int i = 0; i < objAudios.Length; i++)
            {
				audios[i].volume = 0.3f;
                audios[0].volume = 1f;
                imgVolumen.sprite = muted[0];
            }
            PlayerPrefs.SetInt("MusicaOn", 1);
            PlayerPrefs.Save();
        }
        else
        {
            for (int i = 0; i < objAudios.Length; i++)
            {
                audios[i].volume = 0f;
                imgVolumen.sprite = muted[1];
            }
            PlayerPrefs.SetInt("MusicaOn", 0);
            PlayerPrefs.Save();
        }


        /*imgVolumen.sprite = muted[numeroMute];
        numeroMute++;
        if (numeroMute >= muted.Length)
        {
            numeroMute = 0;
        }*/
    }

}
