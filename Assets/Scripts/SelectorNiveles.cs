using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SelectorNiveles : MonoBehaviour {

    [System.Serializable]
    public class Nivel
    {
        public string NumeroNivel;
        public int Desbloqueado;
        public bool Interactuable;
        public Sprite imagenNivel;
        public GameObject candado;
    }
    

    public GameObject botonNivel;
    public Transform Spacer;
    public List<Nivel> ListaNiveles;


    private void Start()
    {
        LlenarLista();
		GuardarCambios();
		PlayerPrefs.Save();
    }


    void LlenarLista()
    {
        foreach (var Nivel in ListaNiveles)
        {
            GameObject nuevoBoton = Instantiate(botonNivel) as GameObject;
			PropiedadesBoton boton = nuevoBoton.GetComponent<PropiedadesBoton>();
            nuevoBoton.GetComponent<Image>().sprite = Nivel.imagenNivel;
            boton.NumeroNivel = Nivel.NumeroNivel;
            


            PlayerPrefs.SetInt("Nivel" + ("Nivel" + boton.NumeroNivel), 1);//


            
            if (PlayerPrefs.GetInt("Nivel"+boton.NumeroNivel) == 1) //kes zesto
            {
                Nivel.Desbloqueado = 1;
                Nivel.Interactuable = true;
                boton.candado.SetActive(false);
                
            }

            boton.Desbloqueado = Nivel.Desbloqueado;
            boton.GetComponent<Button>().interactable = Nivel.Interactuable;
            boton.GetComponent<Button>().onClick.AddListener(() => CargarNiveles("Nivel" + boton.NumeroNivel));


			PlayerPrefs.SetInt("Nivel" + ("Nivel" + boton.NumeroNivel+ "score"), 0);//dddddddddd
            


            if(PlayerPrefs.GetInt("Nivel"+boton.NumeroNivel+"_score")>0)
            {
                boton.Estrella1.SetActive(true);
            }

            if (PlayerPrefs.GetInt("Nivel" + boton.NumeroNivel + "_score") >= 100)
            {
                boton.Estrella2.SetActive(true);
            }

            if (PlayerPrefs.GetInt("Nivel" + boton.NumeroNivel + "_score") >= 200)
            {
                boton.Estrella3.SetActive(true);
            }
			if (Nivel.Interactuable == true)
			{
				boton.candado.SetActive(false);
			}
            nuevoBoton.transform.SetParent(Spacer, false);
        }

        GuardarCambios();
    }
    
    void GuardarCambios()
    {
        if(PlayerPrefs.HasKey("Nivel1"))
        {
            return;
        }
        else
        {
            GameObject[] TodosBotones = GameObject.FindGameObjectsWithTag("BotonNiveles");
            foreach (GameObject botones in TodosBotones)
            {
				PropiedadesBoton boton = botones.GetComponent<PropiedadesBoton>();
                PlayerPrefs.SetInt("Nivel" + boton.NumeroNivel, boton.Desbloqueado);
            }
        }     
    }

    void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
		Debug.Log("DeleteAll");
		Initiate.Fade("Menu", Color.black, 1.0f);
    }


    void CargarNiveles(string value)
    {
        SceneManager.LoadScene(value);
    }
}
