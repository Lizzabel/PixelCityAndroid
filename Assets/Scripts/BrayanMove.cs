using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


	//private Vector3 offset;
	public GameObject Camara;


	public Transform PosArepa;
	public GameObject ArepaPrefab;
    int indicador;
    bool AnimAttack;
    

    //cambiar color boton
    public GameObject botonArepa;
    Image imagenArepa;
    public Color arepaActivo;
    public Color arepaInactivo;
    public AudioSource AudGolpe;

    int comprobarSalto;
    private Vector2 touchOrigin = -Vector2.one; //ni idea que es esto
	int CantidadDisparo;



    void Start()
	{
		RiBo2D_Brayan = Brayan.GetComponent<Rigidbody2D>();
		animBrayan = Brayan.GetComponent<Animator>();
        animBrayan.SetBool("Ground", true);
        imagenArepa = botonArepa.GetComponent<Image>();
        imagenArepa.color = arepaActivo;
        //offset = Camara.transform.position - Brayan.transform.position;
        BrayanPropiedades.Muerto = false;
        atacando = false;
    }

   
    void Update() {

		int horizontal = 0;
        int vertical = 0;

		if (!BrayanPropiedades.Muerto)
		{
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
            
            /*
            if (animBrayan.GetCurrentAnimatorStateInfo(0).IsName("BrayanRunJump") || animBrayan.GetCurrentAnimatorStateInfo(0).IsName("Brayan_Jump"))
            {
                comprobarSalto = 1;
			}*/

            ////////////////////////////////////////// TOUCH
            
            //Get input from the input manager, round it to an integer and store in horizontal to set x axis move direction
            horizontal = (int)(Input.GetAxisRaw("Horizontal"));

            //Get input from the input manager, round it to an integer and store in vertical to set y axis move direction
            vertical = (int)(Input.GetAxisRaw("Vertical"));

            if (horizontal != 0)
            {
                vertical = 0;
            }

            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    //Store the first touch detected.
                    Touch myTouch = Input.touches[i];

                    //Check if the phase of that touch equals Began
                    if (myTouch.phase == TouchPhase.Began)
                    {
                        //If so, set touchOrigin to the position of that touch
                        touchOrigin = myTouch.position;
                    }

                    //If the touch phase is not Began, and instead is equal to Ended and the x of touchOrigin is greater or equal to zero:
                    else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
                    {
                        //Set touchEnd to equal the position of this touch
                        Vector2 touchEnd = myTouch.position;

                        //Calculate the difference between the beginning and end of the touch on the x axis.
                        float x = touchEnd.x - touchOrigin.x;

                        //Calculate the difference between the beginning and end of the touch on the y axis.
                        float y = touchEnd.y - touchOrigin.y;

                        //Set touchOrigin.x to -1 so that our else if statement will evaluate false and not repeat immediately.
                        touchOrigin.x = -1;
                        touchOrigin.y = -1; //yop

                        //Check if the difference along the x axis is greater than the difference along the y axis.
                        if (Mathf.Abs(x) > Mathf.Abs(y))
                            //If x is greater than zero, set horizontal to 1, otherwise set it to -1
                            horizontal = x > 0 ? 1 : -1;
                        else
                            //If y is greater than zero, set horizontal to 1, otherwise set it to -1
                            vertical = y > 0 ? 1 : -1;
                    }
                }
            }

			if (vertical > 0)
            {
				if (comprobarSalto == 0)
                {
					comprobarSalto = 1;
                    animBrayan.SetBool("Ground", false);
					StartCoroutine(SaltarTime());
					saltando = true;
				}
				else if (saltando == false)
                {
					if (animBrayan.GetCurrentAnimatorStateInfo(0).IsName("Brayan_Idle") || animBrayan.GetCurrentAnimatorStateInfo(0).IsName("Brayan_Run"))
                    {
                        comprobarSalto = 0;
                    }
                }
			}
        }

    }
    
	public void MovimientoDer()
	{
        Der = !Der;
        Anim = !Anim;
	}

	public void MovimientoIzq()
    {
		Izq = !Izq;
		Anim = !Anim;
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
    
        yield return new WaitForSecondsRealtime(0.35f);

		if (saltando)
        {
            tocandoPiso = false;
            saltando = false;
            RiBo2D_Brayan.AddForce(new Vector2(0, fuerzaSalto));
            animBrayan.SetBool("Ground", true);
        }

	}

	public void Ataque()
	{
        if (indicador == 0)
        {
            atacando = true;
            AudGolpe.Play();
            imagenArepa.color = arepaInactivo;
            AnimAttack = true;
            animBrayan.SetBool("Attack", AnimAttack);
            StartCoroutine(EsperarAtaque());
        }
    }
       
	void Disparo()
	{
		if (PowerUp.PowerActivo == 0)
		{
			Instantiate(ArepaPrefab, PosArepa.position, PosArepa.rotation);
		}else
		{
			StartCoroutine(DisparoPower());
		}
	}
	IEnumerator DisparoPower()
	{
		yield return new WaitForSecondsRealtime(0.0f);
		if (CantidadDisparo < 5)
		{
			CantidadDisparo++;
			Instantiate(ArepaPrefab, PosArepa.position, PosArepa.rotation);
			StartCoroutine(DisparoPower());
		}
	}

	IEnumerator EsperarAtaque()
	{
        indicador = 1;
        yield return new WaitForSecondsRealtime(0.33f);
        AnimAttack = false;
        Disparo();
        animBrayan.SetBool("Attack", AnimAttack);
        yield return new WaitForSecondsRealtime(0.2f);
        indicador = 0;
        imagenArepa.color = arepaActivo;
		atacando = false;
		yield return new WaitForSecondsRealtime(0.2f);
		CantidadDisparo = 0;

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
