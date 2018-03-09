using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaJugador : MonoBehaviour
{

    public float velocity_bullet;
    private Rigidbody2D controller;



      void Start()
    {

        controller = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        controller.transform.Translate(velocity_bullet * Time.deltaTime, 0, 0);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "muro" || collision.gameObject.tag == "columna")
        {

            Destroy(this.gameObject);
            Debug.Log("Impacto de la bala en el muro");

        }
        else if (collision.gameObject.tag == "bala")
        {
            
            Destroy(this.gameObject);
            Debug.Log("Impacto de la bala en el Jugador");

        }
    }
}
