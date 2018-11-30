using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    int tiempo;
    public Text elTexto;


	void Start () {
        tiempo = 5;
        elTexto.text = tiempo.ToString();
        StartCoroutine(Contador());
	}
	
    IEnumerator Contador()
    {
        if (tiempo<=0)
        {
            Initiate.Fade("Menu", Color.black, 1f);
        }
        else
        {
            yield return new WaitForSecondsRealtime(1f);
            tiempo--;
            elTexto.text = tiempo.ToString();
            StartCoroutine(Contador());
        }
    }

    public void Si()
    {
        Initiate.Fade("Nivel1", Color.black, 1f);
    }
}
