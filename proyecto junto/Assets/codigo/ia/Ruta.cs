using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruta : MonoBehaviour
{

    public bool rutaCorrecta;


    private GameObject [] rutaPosicion;
    private bool rutaNueva = true;


    void Start()
    {

        rutaPosicion = GameObject.FindGameObjectsWithTag("suelo0");
        

    }

    private bool nuevaPosicion()
    {

        return rutaNueva;

    }

    public void nuevaPos(Vector2 posicionEnemigo)
    {
        if (nuevaPosicion())
        {
            int aleatorio = Random.Range(0, rutaPosicion.Length);

            transform.position = rutaPosicion[aleatorio].transform.position;
            rutaNueva = false;
            Debug.Log("Nueva ruta establecida");
        }
        else Debug.Log("LLegando a la ruta...");
    }

    public bool comprobarRuta() {

        return rutaCorrecta;

    }

    public Vector2 getPos() {

        Vector2 pos = transform.position;
        return pos;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "columna")
        {
            Debug.Log("Ruta Invalida : columna");
            rutaCorrecta = false;

         }

        else if (collision.gameObject.tag == "muro")
        {
            Debug.Log("Ruta Invalida : muro");
            rutaCorrecta = false;

        }

         else
        {
           // Debug.Log("Ruta correcta");
            rutaCorrecta = true;

        }

        if (collision.gameObject.tag == "rutas")
        {
            Debug.Log("Ruta completada");
            rutaNueva = true;

        }
    }
}
