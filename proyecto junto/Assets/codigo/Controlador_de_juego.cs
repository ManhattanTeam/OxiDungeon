using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador_de_juego : MonoBehaviour {

    public GameObject EnemigoNormal;

    public void generarEnemigo(Vector3 Posicion) {

        Instantiate(EnemigoNormal, Posicion, EnemigoNormal.transform.rotation);

    }
}
