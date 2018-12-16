using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corazon : MonoBehaviour {

    public float vidaPerro;
    public ParticleSystem particulas;
    public AudioSource AudCorazon;

    private void Start()
    {
        AudCorazon = GameObject.Find("AudioCorazon").GetComponent<AudioSource>();
        particulas.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Player")
        {
            AudCorazon.Play();
            PuntosVida.barraVida.fillAmount = PuntosVida.vida += vidaPerro;
            GetComponent<SpriteRenderer>().enabled = false;
            particulas.gameObject.SetActive(true);
            StartCoroutine(Esperar());
        }
    }
    IEnumerator Esperar()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        Destroy(gameObject);
    }
}
