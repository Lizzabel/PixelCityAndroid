using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public static bool BoolPower = false;
    public static int PowerActivo;

    Collider2D colPower;
    SpriteRenderer rendererPower;
    public ParticleSystem particulas;
	public bool EsPowerPuntos;
	public GameObject powerX2;
    public GameObject barraX2;
	public GameObject powerDisparo;
    public GameObject BarraDisparo;
    public AudioSource AudPower;

    void Start()
    {
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