using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArepaFlotante : MonoBehaviour {

	public int puntosArepa = 5;
	public static bool ContarArepa;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
        {
			ContarArepa = true;
			PuntosVida.puntos += puntosArepa;
            Destroy(gameObject);
        }
	}
}
