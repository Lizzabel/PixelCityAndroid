using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrayanPropiedades : MonoBehaviour {

    
	public float danno = 10f;
	public static bool Muerto;
	public static bool Atacando;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemigo")
		{
			PuntosVida.vida -= danno;
			Atacando = true;

			PuntosVida.barraVida.fillAmount = PuntosVida.vida / PuntosVida.maxVida;

			if (PuntosVida.vida <= 0.0f)
			{
				Muerto = true;
				BrayanMove.animBrayan.SetBool("Die",Muerto); //funciona
				Destroy(gameObject.GetComponent<BoxCollider2D>());
				Destroy(gameObject.GetComponent<Rigidbody2D>());
				Destroy(gameObject.GetComponent<CircleCollider2D>());
			}
		}else
		{
			Atacando = false;
		}
	}
}
