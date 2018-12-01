using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirBajito : MonoBehaviour {


	private void OnTriggerEnter2D(Collider2D trigger)
	{
		if (trigger.gameObject.tag == "EnemigoBajito")
		{
			Debug.Log("entro");
			Destroy(trigger.gameObject);
		}
	}
}
