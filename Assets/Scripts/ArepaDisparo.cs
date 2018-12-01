using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArepaDisparo : MonoBehaviour {


	public float velocidad;
	public Rigidbody2D RB_Arepa;
	public int PuntosPorGolpe;
	public static bool ContarGolpe;

   
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemigo")
		{
			ContarGolpe = true;
			PuntosVida.puntos += PuntosPorGolpe;
			Destroy(gameObject);
		}
		if (collision.gameObject.tag == "EnemigoBajito")
		{
			ContarGolpe = true;
            PuntosVida.puntos += 5;
            Destroy(gameObject);
		}
	}

	void Start () {

		if (!BrayanMove.LadoDerecho)
		{
			RB_Arepa.AddForce(new Vector2(velocidad, 0));
		}else
		{
			RB_Arepa.AddForce(new Vector2(-velocidad, 0));
		}

		StartCoroutine(Esperar());
	}

	IEnumerator Esperar()
	{
		yield return new WaitForSecondsRealtime(1f);
		Destroy(gameObject);
	}

}
