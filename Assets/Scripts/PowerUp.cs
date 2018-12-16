using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public static bool BoolPower = false;
    public static int PowerActivo;

	GameObject powerX2;
    GameObject barraX2;
    GameObject powerDisparo;
    GameObject BarraDisparo;
    AudioSource AudPower;

    Collider2D colPower;
    SpriteRenderer rendererPower;
    public ParticleSystem particulas;
	public bool EsPowerPuntos;

    void Start()
    {
		powerX2 = GameObject.Find("Canvas/PowerUps/PowerUpX2");

		barraX2 = GameObject.Find("Canvas/PowerUps/BarraRoja/BarPwr x2");

		powerDisparo = GameObject.Find("Canvas/PowerUps/PowerUpDisparo");

		BarraDisparo = GameObject.Find("Canvas/PowerUps/BarraVerde/BarPwr Disparo");

		AudPower = GameObject.Find("AudioPower").GetComponent<AudioSource>();
        //
        particulas.gameObject.SetActive(false);
        colPower = gameObject.GetComponent<Collider2D>();
        rendererPower = gameObject.GetComponent<SpriteRenderer>();
        PowerActivo=0;
		BoolPower = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudPower.Play();
            particulas.gameObject.SetActive(true);
            if (EsPowerPuntos == true)
			{
				BoolPower = true;//Puntos
				powerX2.SetActive(true);
                barraX2.SetActive(true);
			}else
			{
				PowerActivo = 1; //Balas
				powerDisparo.SetActive(true);
                BarraDisparo.SetActive(true);
			}
			rendererPower.enabled = false;
            StartCoroutine(BoolFalse());
            colPower.enabled = false;
        }
    }
    IEnumerator BoolFalse()
    {
        yield return new WaitForSecondsRealtime(5f);
		if (EsPowerPuntos == true)
        {
			BoolPower = false;//Puntos
			powerX2.SetActive(false);
        }
        else
        {
            PowerActivo = 0; //Balas
			powerDisparo.SetActive(false);
        }
        Destroy(gameObject);
    }
}