using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrayanMove : MonoBehaviour
{ 
	public GameObject Brayan;
	public Rigidbody2D RiBo2D_Brayan;
	public float Velocidad;

	public static Animator animBrayan;
	bool Der, Izq, Arriba, Anim;
	public static bool LadoDerecho;

	[SerializeField]
	private Transform[] GrupoDePos;

	[SerializeField]
	private float SueloRadios;
	[SerializeField]
	private LayerMask QueEsSuelo;

	private bool tocandoPiso;
	private bool saltando;
	private bool atacando;

	[SerializeField]
	float fuerzaSalto = 5f;


	private Vector3 offset;
	public GameObject Camara;


	public Transform PosArepa;
	public GameObject ArepaPrefab;


    void Start()
	{
		RiBo2D_Brayan = Brayan.GetComponent<Rigidbody2D>();
		animBrayan = Brayan.GetComponent<Animator>();

		offset = Camara.transform.position - Brayan.transform.position;
        BrayanPropiedades.Muerto = false;
	}

   
    void Update() {

		if (!BrayanPropiedades.Muerto)
		{
			if (animBrayan.GetCurrentAnimatorStateInfo(0).IsName("Brayan_Attack"))
			{
				atacando = true;

			}
			else
			{
				atacando = false;
			}


			if (!atacando)
			{
				if (Der == true)
				{
					RiBo2D_Brayan.velocity = new Vector2(Velocidad, RiBo2D_Brayan.velocity.y);
					if (LadoDerecho)
					{
						Girar();
					}

				}

				if (Izq == true)
				{
					RiBo2D_Brayan.velocity = new Vector2(-Velocidad, RiBo2D_Brayan.velocity.y);
					if (!LadoDerecho)
					{
						Girar();
					}
				}
			}
			animBrayan.SetBool("Run", Anim);

			tocandoPiso = TocandoPiso();

			if ((Input.GetKeyDown(KeyCode.Space)) || (SwipeManager.SwipeDirection == Swipe.Up)) // saltar, cambiar por swipe up
			{
				animBrayan.SetBool("Ground", false);
				StartCoroutine(SaltarTime());
			}
			else
			{
				animBrayan.SetBool("Ground", true);
			}
         
		}
        

	}
    
	public void MovimientoDer()
	{
		if (!atacando)
		{
			Der = !Der;
			Anim = !Anim;
		}
	}

	public void MovimientoIzq()
    {
		if (!atacando)
		{
			Izq = !Izq;
			Anim = !Anim;
		}
    }

    public void Girar()
	{ 
		LadoDerecho = !LadoDerecho;
		Vector2 ValorEscala = Brayan.transform.localScale;
		ValorEscala.x *= -1;

		Brayan.transform.localScale = ValorEscala;

	}

	IEnumerator SaltarTime()
	{
		yield return new WaitForSecondsRealtime(0.45f);
		Saltar();
	}

	public void Saltar()
	{
        saltando = true;

		if (tocandoPiso && saltando)
        {
            tocandoPiso = false;
            saltando = false;
            RiBo2D_Brayan.AddForce(new Vector2(0, fuerzaSalto));
        }
	}

	public void Ataque(bool AnimAttack)
	{
        animBrayan.SetBool("Attack", AnimAttack);
        if (!animBrayan.GetCurrentAnimatorStateInfo(0).IsName("Brayan_Attack"))
        {
            if (!AnimAttack)
            {
                StartCoroutine(EsperarAtaque());
            }
        }
	}
       
	void Disparo()
	{
		Instantiate(ArepaPrefab, PosArepa.position, PosArepa.rotation);
	}

	IEnumerator EsperarAtaque()
	{
		yield return new WaitForSecondsRealtime(0.25f);
		Disparo();
	}


	private bool TocandoPiso()
	{
		if (RiBo2D_Brayan.velocity.y <= 0)
		{

			foreach (Transform pos in GrupoDePos)
			{
				Collider2D[] Colliders = Physics2D.OverlapCircleAll(pos.position, SueloRadios, QueEsSuelo);

				for (int i = 0; i < Colliders.Length; i++)
				{
					if (Colliders[i].gameObject != Brayan)
					{
						return true;
					}
				}
			}

		}
		return false;
	}

   
	void LateUpdate()
    {
		Camara.transform.position = new Vector3(Brayan.transform.position.x, Camara.transform.position.y, Camara.transform.position.z);


    }

    


}
