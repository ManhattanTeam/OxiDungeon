using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class IAEnemigo : MonoBehaviour
{
  
    public float Velocidad;
    public GameObject PrefabBala;
    public LayerMask mask;
    public Ruta ruta;
    public int SalaDeVivencia;

    private RaycastHit2D vision;
    private GameObject player;
    private float tiempoDisparo = 0;
    private float tiempoPersecucion = 11;
    private bool SalaCorrecta;

    void Awake()
    {

        player = GameObject.FindWithTag("jugador");
        if (player) Debug.Log("Player encontrado");

    }

    public void setSala(int a) {

        SalaDeVivencia = a;

    }

    private bool deteccionEnemigo()
    {

        vision = Physics2D.Raycast(transform.position, transform.up, 12, mask);

        if (vision.collider.gameObject.tag == "jugador")
        {
            Debug.Log("Jugador Encontrado");
            tiempoPersecucion = 0;
            return true;
        }
        else
        {
            //Debug.Log("Jugador No Encontrado");
            return false;
        }
    }

    void persecucionActiva()
    {

        if (tiempoDisparo >= 1)
        {

            tiempoDisparo = 0;
            Instantiate(PrefabBala, transform.position, player.transform.rotation);

        }

    }

    void irAlJugador() {

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Velocidad * Time.deltaTime);

    }

    void Ruta()
    {

        ruta.nuevaPos(transform.position);
        transform.position = Vector2.MoveTowards(transform.position, ruta.transform.position, Velocidad * Time.deltaTime); // Movimiento del enemigo a la ruta


    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "suelo0" || collision.tag == "baldosa" || collision.tag == "bala" || collision.tag == "columna" || collision.tag == "jugador")
            SalaCorrecta = true;
        else
            SalaCorrecta = false;

        Debug.Log("El enemigo esta en la " + collision);

    }

    void Update()
    {

        if (SalaCorrecta)
        {
            tiempoPersecucion += Time.deltaTime;
            tiempoDisparo += Time.deltaTime;

            if (deteccionEnemigo() || tiempoPersecucion < 11)
            {
                persecucionActiva();
                irAlJugador();

            }
            else
            {

                Ruta();

            }
        }
        //else
        //    Destroy(this.gameObject);

    }

}

