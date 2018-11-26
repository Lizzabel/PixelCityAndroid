using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour {
    int score=10;
    public int numeroNivel;
	// Use this for initialization
	void Start () {

        PlayerPrefs.SetInt("Nivel"+(numeroNivel+1), 1);
        PlayerPrefs.SetInt("Nivel"+numeroNivel+"_score", PuntosVida.puntos);
        //StartCoroutine(Time());
        

	}
	
    IEnumerator Time()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
    
    public void Perder()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.SetInt("Nivel" + numeroNivel + "_score", PuntosVida.puntos);
    }
}
