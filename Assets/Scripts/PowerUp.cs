using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public static bool BoolPower = false;

    Collider2D colPower;
    SpriteRenderer rendererPower;

    void Start()
    {
        colPower = gameObject.GetComponent<Collider2D>();
        rendererPower = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rendererPower.enabled = false;
            BoolPower = true;
            StartCoroutine(BoolFalse());
            colPower.enabled = false;
        }
    }
    IEnumerator BoolFalse()
    {
        yield return new WaitForSecondsRealtime(5f);
        BoolPower = false;
        Destroy(gameObject);
    }
}