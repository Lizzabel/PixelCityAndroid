using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArepaDisparo : MonoBehaviour {


	public float velocidad;
	public Rigidbody2D RB_Arepa;
	public int PuntosPorGolpe;
	public static bool ContarGolpe;
    public int PuntosBajito =5;
    bool bajito;

   
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemigo")
		{
            bajito = false;
			ContarGolpe = true;
            Power();
			Destroy(gameObject);
		}
		if (collision.gameObject.tag == "EnemigoBajito")
		{
            bajito = true;
			ContarGolpe = true;
            Power();
            Destroy(gameObject);
		}
	}
    public void Power()
    {
        if(bajito==false)
        {
            if (PowerUp.BoolPower)
            {
                PuntosVida.puntos += (PuntosPorGolpe * 2);
            }
            else
            {
                PuntosVida.puntos += PuntosPorGolpe;
            }
        }
        else
        {
            if (PowerUp.BoolPower)
            {
                PuntosVida.puntos += (PuntosBajito * 2);
            }
            else
            {
                PuntosVida.puntos += PuntosBajito;
            }
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
