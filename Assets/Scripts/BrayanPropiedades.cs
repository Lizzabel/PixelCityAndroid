using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrayanPropiedades : MonoBehaviour {

    
	public int danno = 10;
	public static bool Muerto;
	public static bool Atacando;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemigo")
		{
			PuntosVida.vida -= danno;
			Atacando = true;

			if (PuntosVida.vida <= 0)
			{
				Muerto = true;
				BrayanMove.animBrayan.SetBool("Die",Muerto); //funciona
			}
		}else
		{
			Atacando = false;
		}
	}
}
