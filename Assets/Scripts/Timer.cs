using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour {
    int score=10;
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Nivel2", 1);
        PlayerPrefs.SetInt("Nivel1_score", score);
        StartCoroutine(Time());
	}
	
    IEnumerator Time()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
