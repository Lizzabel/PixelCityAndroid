using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectorNiveles : MonoBehaviour {

    [System.Serializable]
    public class Nivel
    {
        public int Desbloqueado;
        public bool Interactuable;
        public Sprite imagenNivel;

        public Button.ButtonClickedEvent OnClickEvent;
    }


    public GameObject botonNivel;
    public Transform Spacer;
    public List<Nivel> ListaNiveles;


    private void Start()
    {
        LlenarLista();
    }


    void LlenarLista()
    {
        foreach (var Nivel in ListaNiveles)
        {
            GameObject nuevoBoton = Instantiate(botonNivel) as GameObject;
            BotonNiveles boton = nuevoBoton.GetComponent<BotonNiveles>();
            nuevoBoton.GetComponent<Image>().sprite = Nivel.imagenNivel;


            nuevoBoton.transform.SetParent(Spacer, false);
        }
    }
    
}
