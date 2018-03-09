using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{

    private GameObject jugador;
    private Animator anim;


    // Use this for initialization
    void Start()
    {


        anim = GetComponent<Animator>();

    }

    public void getHit()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        jugador = GameObject.FindWithTag("jugador");
        this.gameObject.transform.position = new Vector3(jugador.transform.position.x, jugador.transform.position.y, -10);
        //if (!jugador) Debug.Log("No se ha detectado al jugador: Camara");
        //else if (jugador) Debug.Log("Se ha detectado al jugador: Camara");

    }
}
