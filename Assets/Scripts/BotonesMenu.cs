using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotonesMenu : MonoBehaviour {

    public Color colorEscena;
    public string nombreEscena;
    public float tiempoEscena;

    public void Jugar()
    {
        Initiate.Fade(nombreEscena, colorEscena, tiempoEscena);
    }

}
