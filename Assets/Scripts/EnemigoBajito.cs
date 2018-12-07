using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoBajito : MonoBehaviour
{

    Transform Transplayer;
	//
	Animator animEnemigo;

    public bool cerca;
    //Rigidbody2D rbenemigo;
    public float velocidad;

    float pos;
	float direccion;

    private void Start()
    {
        Transplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		animEnemigo = gameObject.GetComponent<Animator>();
        //rbenemigo = gameObject.GetComponent<Rigidbody2D>();
		cerca = true;
        Girar();
    }

    private void OnCollisionEnter2D(Collision2D colisionEnemigo)
    {
        if (colisionEnemigo.gameObject.tag == "arepaAttack")
        {
			Girar();
			StartCoroutine(EsperarCerca());
        }
        
        if (colisionEnemigo.gameObject.tag == "Player")
        {
            StartCoroutine(EsperarCerca());
        }

    }

    IEnumerator EsperarCerca()
    {
        cerca = false;
		animEnemigo.speed = 0;
        yield return new WaitForSecondsRealtime(0.5f);
        cerca = true;
		animEnemigo.speed = 1;
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
        }
    }
       
    public void Girar()
    {
		pos = Transplayer.position.x - transform.position.x;

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
