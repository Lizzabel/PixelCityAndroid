using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirBajito : MonoBehaviour {

    bool perro;

    private void Start()
    {
        perro = false;
    }

    private void OnTriggerEnter2D(Collider2D trigger)
	{
		if (trigger.gameObject.tag == "EnemigoBajito")
		{
			Debug.Log("entro");
			Destroy(trigger.gameObject);
		}
        if (trigger.gameObject.tag == "Perrito")
        {
            if (perro)
            {
                Destroy(trigger.gameObject);
            }else
            {
                StartCoroutine(Esperar());
            }

        }
    }
    IEnumerator Esperar()
    {
        yield return new WaitForSecondsRealtime(2f);
        perro = true;
    }
}
