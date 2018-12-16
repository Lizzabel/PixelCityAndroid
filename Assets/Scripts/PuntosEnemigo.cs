using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntosEnemigo : MonoBehaviour {
    
   Transform Transplayer;
	//

	public float vidaEnemigo = 100f;
	public float dannoEnemigo = 20f;
	Animator animEnemigo;
    
    public bool cerca;
    public bool morir;
    Rigidbody2D rbenemigo;
    public float velocidad;

    float pos;

    private void Start()
	{
		Transplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

		animEnemigo = gameObject.GetComponent<Animator>();
		rbenemigo = gameObject.GetComponent<Rigidbody2D>();
	}

    private void OnCollisionEnter2D(Collision2D colisionEnemigo)
    {
        if (colisionEnemigo.gameObject.tag == "arepaAttack")
        {
            cerca = true;
            StartCoroutine(MuerteComprobador());
        }

		if (colisionEnemigo.gameObject.tag == "Player")
		{
			StartCoroutine(EsperarCerca());
		}

    }

	private void OnTriggerEnter2D(Collider2D trigger)
	{

		if (trigger.gameObject.tag == "Player")
        {
			cerca = true;
        }
	}

	void OnTriggerExit2D(Collider2D trigger)
    {
		if (trigger.gameObject.tag == "Player")
        {
			cerca = false;
        }
    }

	IEnumerator EsperarCerca()
	{
		cerca = false;
		yield return new WaitForSecondsRealtime(0.5f);
		cerca = true;
	}

	IEnumerator MuerteComprobador()
    {
		vidaEnemigo -= dannoEnemigo;
		if (vidaEnemigo <= 0f)
        {
            morir = true;
            Morir();
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            Destroy(gameObject.GetComponent<EdgeCollider2D>());
            Destroy(rbenemigo);

            yield return new WaitForSecondsRealtime(3.5f);
            Destroy(gameObject);
        }
    }
       
    private void Update()
    {
        Correr();
    }

    public void Correr()
    {
		if (!BrayanPropiedades.Muerto)
		{
            if (cerca)
            {
                if (vidaEnemigo > 0f)
                {
                    transform.position = Vector2.MoveTowards(transform.position,
                                        new Vector2(Transplayer.position.x, transform.position.y), velocidad * Time.deltaTime);
                    //

                    pos = Transplayer.position.x - transform.position.x;
                    Girar();
                }
            }

			animEnemigo.SetBool("correr", cerca);
		}else
		{
			animEnemigo.SetBool("correr", false);
		}
    }

    public void Morir()
    {
       cerca = false;
       animEnemigo.SetBool("muerte", morir);
    }

    public void Girar()
    {
        Vector2 giro = gameObject.transform.localScale;
        //giro.x *= -1;

        if (pos > 0)
        {
            giro.x = 3;
        }
        else if (pos < 0)
        {
            giro.x = -3;
        }
        gameObject.transform.localScale = giro;
    }

}
