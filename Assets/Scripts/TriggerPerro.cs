using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPerro : MonoBehaviour {

	Transform Transplayer;
	Animator AnimPerro;
	bool cerca;

	float pos;
    float direccion;
	public float velocidad;
	int Indicador;
	bool detenerse;
	Vector2 giro;

    int comprobador = 0;

    private void Start()
	{
		AnimPerro = gameObject.GetComponent<Animator>();
		Transplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		Girar();
		Indicador = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (comprobador == 0)
            {
                velocidad *= 3.0f;
                comprobador = 1;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D trigger)
	{
		if (trigger.gameObject.tag == "Player")
		{
			if (Indicador == 0)
			{
				StartCoroutine(Esperar());
			}
		}
	}
	IEnumerator Esperar()
	{
        Indicador = 1;
        yield return new WaitForSecondsRealtime(0.25f);
        Girar2();
        AnimPerro.SetBool("Sentado", true);
        detenerse = true;

        yield return new WaitForSecondsRealtime(4.25f);
		AnimPerro.SetBool("Sentado", false);
        detenerse = false;
        velocidad *= -1.0f;

        if (detenerse == false)
        {
            Destroy(gameObject.GetComponent<BoxCollider2D>());
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
			if (detenerse == false)
			{
				if (pos > 0)
				{
                    direccion = pos++;

				}
				else if (pos < 0)
				{
                    direccion = pos--;

				}
				transform.position = Vector2.MoveTowards(transform.position,
								 new Vector2(direccion, transform.position.y), velocidad * Time.deltaTime);
			}
            else
            {
                direccion = 0.0f;
                transform.position = Vector2.MoveTowards(transform.position,
                 new Vector2(direccion, transform.position.y), 0.0f);
            }
        }
    }

	public void Girar()
    {
        pos = Transplayer.position.x - transform.position.x;

        giro = gameObject.transform.localScale;
        //giro.x *= -1;

        if (pos > 0)
        {
			giro.x = -3;
        }
        else if (pos < 0)
        {
			giro.x = 3;
        }
        gameObject.transform.localScale = giro;
    }

    public void Girar2()
    {
        pos = Transplayer.position.x - transform.position.x;

        giro = gameObject.transform.localScale;
        //giro.x *= -1;

        if (pos < 0)
        {
            giro.x = -3;
        }
        else if (pos > 0)
        {
            giro.x = 3;
        }
        gameObject.transform.localScale = giro;
    }
}
