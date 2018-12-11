using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrayanPropiedades : MonoBehaviour {

	public int nivel;
    
	public float danno;
	public static bool Muerto;
	public static bool Atacando;
    public GameObject GameOver;
 
	public float CountdownValue;
	public GameObject TimerObject;
	Text elTiempo;


	private void Start()
	{
		if (nivel == 2)
		{
			TimerObject.SetActive(true);
			elTiempo = TimerObject.GetComponent<Text>();
			StartCoroutine(EsperarContador());
            
		}else
		{
			TimerObject.SetActive(false);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if ((collision.gameObject.tag == "Enemigo") || (collision.gameObject.tag == "EnemigoBajito"))
		{
			PuntosVida.vida -= danno;
			Atacando = true;

			PuntosVida.barraVida.fillAmount = PuntosVida.vida / PuntosVida.maxVida;

			if (PuntosVida.vida <= 0.0f)
			{
                StartCoroutine(EsperarMuerte());
			}
		}else
		{
			Atacando = false;
		}
	}

    IEnumerator EsperarMuerte()
    {
		Muerto = true;
        BrayanMove.animBrayan.SetBool("Die", Muerto);

        yield return new WaitForSecondsRealtime(2f);

        Destroy(gameObject.GetComponent<BoxCollider2D>());
        Destroy(gameObject.GetComponent<Rigidbody2D>());
        Destroy(gameObject.GetComponent<CircleCollider2D>());
        GameOver.SetActive(true);
    }

	IEnumerator EsperarContador()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        CountdownValue--;
        UpdateLevelTimer(CountdownValue);
    }

	public void UpdateLevelTimer(float totalSeconds)
    {
		if(CountdownValue >= 0)
		{
			int minutes = Mathf.FloorToInt(totalSeconds / 60f);
			int seconds = Mathf.RoundToInt(totalSeconds % 60f);
            string formatedSeconds = seconds.ToString();
            
			if (seconds == 60)
			{
				seconds = 0;
				minutes += 1;
			}
			elTiempo.text = minutes.ToString("00") + ":" + seconds.ToString("00");
			StartCoroutine(EsperarContador());
		}
		else if (CountdownValue <= 0.0f){
			StartCoroutine(EsperarMuerte());
		}
      }

}
