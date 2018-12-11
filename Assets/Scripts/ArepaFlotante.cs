using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArepaFlotante : MonoBehaviour {

	public int puntosArepa = 5;
    int puntosPower;

	public static bool ContarArepa;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
        {
			ContarArepa = true;
            Power();
            Destroy(gameObject);
        }
	}
    public void Power()
    {
        if (PowerUp.BoolPower)
        {
            PuntosVida.puntos += (puntosArepa*2);
        }
        else
        {
            PuntosVida.puntos += puntosArepa;
        }
    }
}
