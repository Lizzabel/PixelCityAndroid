using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corazon : MonoBehaviour {

    public float vidaPerro;

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Player")
        {
            PuntosVida.barraVida.fillAmount = PuntosVida.vida += vidaPerro;
            Destroy(gameObject);
        }
    }
}
