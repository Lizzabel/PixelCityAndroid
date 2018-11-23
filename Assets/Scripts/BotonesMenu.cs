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


}
