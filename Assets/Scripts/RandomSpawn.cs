using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour {

    public GameObject[] Enemigos;
    public int CantidadEnemigos;
    int rango;
    int conteo;
    public float TiempoSpawn;

	void Start () {
        conteo = 1;
        StartCoroutine(EsperarSpawn());
	}


    IEnumerator EsperarSpawn()
    {
        if (conteo <= CantidadEnemigos)
        {
            yield return new WaitForSecondsRealtime(TiempoSpawn);
            conteo++;
            rango = Random.Range(0, (Enemigos.Length));
            Instantiate(Enemigos[rango], transform.position, transform.rotation);
            StartCoroutine(EsperarSpawn());
        }


    }
}
