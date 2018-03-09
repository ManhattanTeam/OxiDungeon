using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class IAEnemigo : MonoBehaviour
{

    private GameObject player;

    [Range(0, 7)]
    public float velocity;
    private Rigidbody2D controller;
    private Vector3 x, y;
    Vector2 vectorMovimientoFinal;
    private Animator anim;


    void Start()
    {

        player = GameObject.FindWithTag("jugador");
        if (player) Debug.Log("Player encontrado");

        controller = GetComponent<Rigidbody2D>();
        x = new Vector3(1, 0, 0);
        y = new Vector3(0, 1, 0);

        anim = GetComponent<Animator>();

    }

 
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, velocity * Time.deltaTime);

        setAnim();
        anim.SetInteger("Direccion", setAnim());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "jugador")
        {
            
            Destroy(this.gameObject);
            // Debug.Log(this);
        }
    }

    private int setAnim()
    {

        Vector3 direccionAnim = player.transform.position -  transform.position;
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

}

