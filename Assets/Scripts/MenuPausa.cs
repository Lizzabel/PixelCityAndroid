using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour {
    public GameObject MenuPausaUI;
    AudioSource elAudio;

    public GameObject botonVolumen;
    Image imgVolumen;
    int numeroMute = 1;
    public Sprite[] muted;

    private void Start()
    {
        elAudio = gameObject.GetComponent<AudioSource>();
        imgVolumen = botonVolumen.GetComponent<Image>();
        imgVolumen.sprite = muted[0];
    }

    public void ActivarPausa()
    {
        MenuPausaUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void DesactivarPausa()
    {
        MenuPausaUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ActivarMenuPrincipal()
    {
		DesactivarPausa();
		Initiate.Fade("Menu", Color.black, 1.0f);
    }

    public void MutearLosAudios()
    {
        //elAudio.mute = !elAudio.mute;
        imgVolumen.sprite = muted[numeroMute];
        numeroMute++;
        if (numeroMute >= muted.Length)
        {
            numeroMute = 0;
        }
    }
}
