using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirBajitoBG : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "EnemigoBajito")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Perro")
        {
            Destroy(collision.gameObject);
        }
	}

}
