using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour {


	public float velocidad;
	public static BackGroundScroll current;
	public SpriteRenderer BG;

	public float pos = 0f;

	void Start () {

		current = this;
	}

	public void Move() {
        
		pos += velocidad;
        if (pos > 1.0f)
		{
			pos -= 1.0f;
		}

		BG.material.mainTextureOffset = new Vector2(pos, 0);
	}
    
}
