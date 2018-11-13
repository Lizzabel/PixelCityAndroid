using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntosEnemigo : MonoBehaviour {
    public int puntos = 10;
    Animator animEnemigo;

    private void Start()
    {
        animEnemigo = gameObject.GetComponent<Animator>();
        StartCoroutine(MuerteComprobador());
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
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            yield return new WaitForSecondsRealtime(2.5f);
            Destroy(gameObject);
        }

        StartCoroutine(MuerteComprobador());
    }
    
    





}
