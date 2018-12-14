using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public static bool BoolPower = false;
    public static int PowerActivo;

    Collider2D colPower;
    SpriteRenderer rendererPower;

    void Start()
    {
        colPower = gameObject.GetComponent<Collider2D>();
        rendererPower = gameObject.GetComponent<SpriteRenderer>();
        PowerActivo=0;
}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rendererPower.enabled = false;
            PowerActivo = 1;
            BoolPower = true;
            StartCoroutine(BoolFalse());
            colPower.enabled = false;
        }
    }
    IEnumerator BoolFalse()
    {
        yield return new WaitForSecondsRealtime(5f);
        BoolPower = false;
        PowerActivo = 0;
        Destroy(gameObject);
    }
}