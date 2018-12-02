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

	private void Start()
	{
		AnimPerro = gameObject.GetComponent<Animator>();
		Transplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		Girar();
		Indicador = 0;
	}

	void OnTriggerEnter2D(Collider2D trigger)
	{
		if (trigger.gameObject.tag == "Player")
		{
			if (Indicador == 0)
			{
				cerca = true;
				giro = gameObject.transform.localScale;
                giro.x *= -1;
                gameObject.transform.localScale = giro;
				AnimPerro.SetBool("Sentado", true);
				StartCoroutine(Esperar());
				Indicador = 1;
               
			}

		}
	}
	IEnumerator Esperar()
	{
		detenerse = true;
		yield return new WaitForSecondsRealtime(4.5f);
		detenerse = false;

		AnimPerro.SetBool("Sentado", false);
	}
	private void Update()
	{

		Correr();
	}

	public void Correr()
    {
        if (!BrayanPropiedades.Muerto)
        {
			if (!detenerse)
			{
				if (pos > 0)
				{
					if (cerca)
					{
						direccion = pos++;
					}
					else
					{
						direccion = pos--;
					}

				}
				else if (pos < 0)
				{
					if (cerca)
					{
						direccion = pos--;
					}
					else
					{
						direccion = pos++;
					}
				}
				transform.position = Vector2.MoveTowards(transform.position,
								 new Vector2(direccion, transform.position.y), velocidad * Time.deltaTime);
			}
			Debug.Log(cerca);
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
}
