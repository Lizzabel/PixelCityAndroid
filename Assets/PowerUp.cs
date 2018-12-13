using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
    public static bool BoolPower = false;

	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PuntosDobles")
        {
            BoolPower = true;
            StartCoroutine(BoolFalse());
        }
    }
    IEnumerator BoolFalse()
    {
        yield return new WaitForSecondsRealtime(5f);
        BoolPower = false;
    }
}
