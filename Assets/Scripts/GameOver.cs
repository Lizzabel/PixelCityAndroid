using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    int tiempo;
    public Text elTexto;
	public int numeroNivel;


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
        if (numeroNivel == 1)
        {
            Initiate.Fade("Nivel2", Color.black, 1.0f);
        }
        else if (numeroNivel == 2)
        {
            Initiate.Fade("Nivel3", Color.black, 1.0f);
        }
        else if (numeroNivel == 3)
        {
            Initiate.Fade("Nivel4", Color.black, 1.0f);
        }
        else
        {
            Initiate.Fade("Menu", Color.black, 1.0f);
        }

    }
}
