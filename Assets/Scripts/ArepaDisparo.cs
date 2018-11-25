using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArepaDisparo : MonoBehaviour {


	public float velocidad;
	public Rigidbody2D RB_Arepa;

	void Start () {

		if (!BrayanMove.LadoDerecho)
		{
			RB_Arepa.AddForce(new Vector2(velocidad, 0));
		}else
		{
			RB_Arepa.AddForce(new Vector2(-velocidad, 0));
		}

	}

}
