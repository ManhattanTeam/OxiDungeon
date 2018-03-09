using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class IAEnemigo : MonoBehaviour
{

    private GameObject player;
    private control_jugador vidasDelJugador;

    [Range(0, 7)]
    public float velocity;
    private Rigidbody2D controller;
    private Vector3 x, y;
    Vector2 vectorMovimientoFinal;
    private Animator anim;
    public bool destroy = false;
    public enum typeOfEnemy { Bombita, corredor };
    public typeOfEnemy controltype = typeOfEnemy.Bombita;
    private Rigidbody2D rb;

    public int vidas = 5;


    void Start()
    {

        player = GameObject.FindWithTag("jugador");
      //  if (player) Debug.Log("Player encontrado");

        controller = GetComponent<Rigidbody2D>();
        x = new Vector3(1, 0, 0);
        y = new Vector3(0, 1, 0);

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        vidasDelJugador = player.GetComponent<control_jugador>();

    }

    public void destroyEnemy()
    {

        Destroy(this.gameObject);

    }

    public void quitarVidas(int vidasASustraer) {

        vidas = vidas - vidasASustraer;
    }

    Vector3 posicionExplosionBomba;


    void Update()
    {


        if (destroy || vidas <= 0)
        {


            if (controltype == typeOfEnemy.corredor)
            {
                // Debug.Log("CORREDOR ELIMINADO");
                destroyEnemy();

            }
            else if (controltype == typeOfEnemy.Bombita)
            {

                destroyEnemy();

            }
        }
        else
            destroy = false;
       

        if (controltype == typeOfEnemy.corredor)
        {

            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, velocity * Time.deltaTime);
            setAnim();
            anim.SetInteger("Direccion", setAnim());


        }
        else if (controltype == typeOfEnemy.Bombita)
        {



            if (anim.GetInteger("Direccion") <= 5)
            {


                Vector3 direccionAnim = player.transform.position - transform.position;
                float distancia = direccionAnim.magnitude;
                Vector3 direccion = direccionAnim / distancia;
               // Debug.Log(distancia);

                if (distancia > 5)
                {
                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, velocity * Time.deltaTime);
                    setAnim();
                    anim.SetInteger("Direccion", setAnim());

                }

                else if (distancia <= 5 && distancia > 2)
                {

                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, velocity * Time.deltaTime * 3);
                    posicionExplosionBomba = player.transform.position;
                    setAnim();
                    anim.SetInteger("Direccion", setAnim());

                }
                else if (distancia <= 2)
                {
                    transform.position = Vector3.MoveTowards(transform.position, posicionExplosionBomba, velocity * Time.deltaTime * 3);
                    //rb.constraints = RigidbodyConstraints2D.FreezePosition;
                    anim.SetInteger("Direccion", 8);
                    //  Debug.Log("He entrado en la animacion final");

                }
                // Debug.Log("Mi distancia es de:  " + distancia);
                //Debug.Log("Mi animacion es la numero:  " + anim.GetInteger("Direccion"));



            }


        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "jugador")
        {
            if (controltype == typeOfEnemy.corredor)
            {
                destroy = true;
                vidasDelJugador.vidas--;
            }
            else if (controltype == typeOfEnemy.Bombita)
            {

                vidasDelJugador.vidas = vidasDelJugador.vidas - 3;
               // destroyEnemy();
              
            }

        }
    }

    private int setAnim()
    {

        Vector3 direccionAnim = player.transform.position - transform.position;
        float distancia = direccionAnim.magnitude;
        Vector3 direccion = direccionAnim / distancia;

        if (direccion.x < 0) //DERECHA
            return 2;
        else if (direccion.x > 0) //Izquierda
            return 4;
        else if (direccion.y < 0) //ARRIBA
            return 1;
        else if (direccion.y > 0) //ABAJO
            return 3;
        else
            return 5;




    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "bala")
        {
            vidas--;
            Debug.Log("Me quedan: " + vidas);

        }
    }

}

