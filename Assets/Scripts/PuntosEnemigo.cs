using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntosEnemigo : MonoBehaviour {
    public int puntos = 10;
    Animator animEnemigo;

    //public GameObject enemigo; // lo quite porque vamos a obtenerlo directamente desde donde esta el codigo, no desde un masterScript
    public bool cerca;
    public bool morir;
    Rigidbody2D rbenemigo;
    public float velocidad;

    private void Start()
    {
        animEnemigo = gameObject.GetComponent<Animator>();
        StartCoroutine(MuerteComprobador());
        rbenemigo = gameObject.GetComponent<Rigidbody2D>(); // ya no obtiene el componente desde una variable Gameobject publica sino que desde el propio gameobject de en donde esta el codigo
    }

    private void OnCollisionEnter2D(Collision2D colisionEnemigo)
    {
        if (colisionEnemigo.gameObject.tag == "Arepa")
        {
            puntos -= 2;
            Debug.Log(puntos);
        }
    }
    IEnumerator MuerteComprobador()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        if (puntos <= 0)
        {
            animEnemigo.SetBool("muerte", true);
            Destroy(gameObject.GetComponent<Collider2D>());

            //Destroy(gameObject.GetComponent<Rigidbody2D>()); lo cambie porque ya en el estar se obtiene el componente
            Destroy(rbenemigo);
            yield return new WaitForSecondsRealtime(2.5f);
            Destroy(gameObject);
        }

        StartCoroutine(MuerteComprobador());
    }


    /// <summary>
    /// Union de codigos Isa
    /// </summary>

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
        Vector2 giro = gameObject.transform.localScale;
        giro.x *= -1;
        gameObject.transform.localScale = giro;
    }

}
