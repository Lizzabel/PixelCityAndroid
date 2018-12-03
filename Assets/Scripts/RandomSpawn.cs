using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour {

    public GameObject perrito;
    public GameObject EnemigoBajito;
    public bool EsEnemigoBajito;
	public bool ActTriggerAdelante;

	public GameObject[] Enemigos;
    public int CantidadEnemigos;
    int rango;
    int conteo;
    public float TiempoSpawn;

	int Adelante = 1;
	int Atras = 1;

	void Start () {
		
			conteo = 1;
	}

	private void OnTriggerEnter2D(Collider2D trigger)
	{
        if (trigger.gameObject.tag == "TriggerAdelante")
		{
            StartCoroutine(EsperarSpawn());
        }
		if (trigger.gameObject.tag == "TriggerAtras")
        {
            StartCoroutine(EsperarSpawn2());
        }
	}


	IEnumerator EsperarSpawn()
    {

		if (Adelante == 1)
		{
			if (ActTriggerAdelante)
			{
				if (!EsEnemigoBajito)
                {
                    if (conteo <= CantidadEnemigos)
                    {
						rango = Random.Range(0, (Enemigos.Length));
                        Instantiate(Enemigos[rango], transform.position, transform.rotation);
                        yield return new WaitForSecondsRealtime(TiempoSpawn);
                        conteo++;
                        StartCoroutine(EsperarSpawn());
					}else
					{
                        Instantiate(perrito, transform.position, transform.rotation);
                        Destroy(gameObject);
						Adelante = 2;
					}
                }
                else
                {
                    Instantiate(perrito, transform.position, transform.rotation);
                    Instantiate(EnemigoBajito, transform.position, transform.rotation);
					Adelante = 2;
                }
			}
		}

    }

	IEnumerator EsperarSpawn2()
	{
		if (Atras == 1)
        {
            if (!ActTriggerAdelante)
            {
                if (!EsEnemigoBajito)
                {
                    if (conteo <= CantidadEnemigos)
                    {
						rango = Random.Range(0, (Enemigos.Length));
                        Instantiate(Enemigos[rango], transform.position, transform.rotation);
                        yield return new WaitForSecondsRealtime(TiempoSpawn);
                        conteo++;
                        StartCoroutine(EsperarSpawn2());
					}else
                    {
                        Instantiate(perrito, transform.position, transform.rotation);
                        Destroy(gameObject);
						Atras = 2;
                    }
                }
                else
                {
                    Instantiate(perrito, transform.position, transform.rotation);
                    Instantiate(EnemigoBajito, transform.position, transform.rotation);
					Destroy(gameObject);
                    Atras = 2;
                }
            }
        }
	}
}
