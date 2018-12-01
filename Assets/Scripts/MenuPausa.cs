using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour {

	public GameObject BotonPausa;
    public GameObject MenuPausaUI;
    public GameObject Listener;
    AudioListener elAudio;

    public GameObject botonVolumen;
    Image imgVolumen;
    int numeroMute = 1;
    public Sprite[] muted;

    //AudioSource[] audios;
    //public GameObject[] objAudios;

    private void Start()
    {
        elAudio = Listener.GetComponent<AudioListener>();
        imgVolumen = botonVolumen.GetComponent<Image>();
        imgVolumen.sprite = muted[0];
		BotonPausa.SetActive(true);
		PlayerPrefs.Save();
		/*
        audios = new AudioSource[objAudios.Length];

        for (int i = 0; i < objAudios.Length; i++)
        {
            audios[i] = objAudios[i].GetComponent<AudioSource>();
        }
        */
        if (PlayerPrefs.GetInt("MusicaOn") == 0)
		{
			MutearLosAudios();
		}

    }

    public void ActivarPausa()
    {
        MenuPausaUI.SetActive(true);
        Time.timeScale = 0f;
		BotonPausa.SetActive(false);
    }

    public void DesactivarPausa()
    {
        MenuPausaUI.SetActive(false);
        Time.timeScale = 1f;
		BotonPausa.SetActive(true);
    }

    public void ActivarMenuPrincipal()
    {
		DesactivarPausa();
		Initiate.Fade("Menu", Color.black, 1.0f);
    }

    public void MutearLosAudios()
    {
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

        imgVolumen.sprite = muted[numeroMute];
        numeroMute++;
        if (numeroMute >= muted.Length)
        {
            numeroMute = 0;
        }
    }
}
