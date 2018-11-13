using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour {
    public GameObject enemigo;
    Animator animEnemigo;
    public bool cerca;
    public bool morir;
    Rigidbody2D rbenemigo;
    public float velocidad;


	// Use this for initialization
	void Start ()
    {
        animEnemigo = enemigo.GetComponent<Animator>();
        rbenemigo = enemigo.GetComponent<Rigidbody2D>();
	}

    private void Update()
    {
        Correr();
        Morir();
    }

    public void Correr()
    {
        if (cerca)
        {
            rbenemigo.velocity = new Vector2(velocidad, rbenemigo.velocity.y);

        }
        animEnemigo.SetBool("correr", cerca);
    }

    public void Morir()
    {
        if (morir)
        {
            cerca = false;
            animEnemigo.SetBool("muerte", morir);
        }
    }

    public void Girar()
    {
        Vector2 giro = enemigo.transform.localScale;
        giro.x *= -1;
        enemigo.transform.localScale = giro;
    }


}
