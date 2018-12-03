using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrayanPropiedades : MonoBehaviour {

    
	public float danno;
	public static bool Muerto;
	public static bool Atacando;
    public GameObject GameOver; 

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if ((collision.gameObject.tag == "Enemigo") || (collision.gameObject.tag == "EnemigoBajito"))
		{
			PuntosVida.vida -= danno;
			Atacando = true;

			PuntosVida.barraVida.fillAmount = PuntosVida.vida / PuntosVida.maxVida;

			if (PuntosVida.vida <= 0.0f)
			{
				Muerto = true;
				BrayanMove.animBrayan.SetBool("Die",Muerto); //funciona
                StartCoroutine(EsperarMuerte());
			}
		}else
		{
			Atacando = false;
		}
	}
    IEnumerator EsperarMuerte()
    {
        yield return new WaitForSecondsRealtime(2f);
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        Destroy(gameObject.GetComponent<Rigidbody2D>());
        Destroy(gameObject.GetComponent<CircleCollider2D>());
        GameOver.SetActive(true);
    }
}
