using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArepaDisparo : MonoBehaviour {


	public float velocidad;
	public Rigidbody2D RB_Arepa;
    public ParticleSystem particulas;
	public int PuntosPorGolpe;
	public static bool ContarGolpe;
    public int PuntosBajito =5;
    AudioSource auArepazo;

    bool bajito;
    

    void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemigo")
		{
            auArepazo.Play();
            particulas.gameObject.SetActive(true);
            Destroy(gameObject.GetComponent<CircleCollider2D>());
            GetComponent<SpriteRenderer>().enabled = false;
            bajito = false;
			ContarGolpe = true;
            Power();
            EsperarArepas();
		}
		if (collision.gameObject.tag == "EnemigoBajito")
		{
            auArepazo.Play();
            particulas.gameObject.SetActive(true);
            Destroy(gameObject.GetComponent<CircleCollider2D>());
            GetComponent<SpriteRenderer>().enabled = false;
            bajito = true;
			ContarGolpe = true;
            Power();
            EsperarArepas();
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

	void Start ()
    {
        auArepazo = GameObject.Find("AudioArepazo").GetComponent<AudioSource>();
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

    IEnumerator EsperarArepas()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        Destroy(gameObject);
    }
}
