using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DisparoBalas : MonoBehaviour
{

    public float velocity_bullet;
    private GameObject player;
    Vector2 directionVector;


    // Use this for initialization
    void Start()
    {

        player = GameObject.FindWithTag("jugador");
        directionVector = (player.transform.position - transform.position).normalized;

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(directionVector * velocity_bullet * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "muro" || collision.gameObject.tag == "columna")
        {

            Destroy(this.gameObject);
            Debug.Log("Impacto de la bala en el muro");

        }
        else if (collision.gameObject.tag == "jugador")
        {

            Destroy(this.gameObject);
            Debug.Log("Impacto de la bala en el Jugador");

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if (collision.gameObject.tag == "muro" || collision.gameObject.tag == "columna")
        {

            Destroy(this.gameObject);
            Debug.Log("Impacto de la bala en el muro");

        }
        else if (collision.gameObject.tag == "jugador")
        {

            Destroy(this.gameObject);
            Debug.Log("Impacto de la bala en el Jugador");

        }
    }
}
