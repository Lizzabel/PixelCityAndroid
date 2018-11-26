using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NivelManager : MonoBehaviour {
	
    int score=10;
    public int numeroNivel;

	void Start () {

        PlayerPrefs.SetInt("Nivel"+(numeroNivel+1), 1);
        PlayerPrefs.SetInt("Nivel"+numeroNivel+"_score", PuntosVida.puntos);

	}

    public void Perder()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.SetInt("Nivel" + numeroNivel + "_score", PuntosVida.puntos);
    }
}
