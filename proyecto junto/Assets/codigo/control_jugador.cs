using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_jugador : MonoBehaviour {
    
    [Range(0,500)]
    public float velocidad;
    SpriteRenderer sprites;
    Rigidbody2D controller;
    Vector3 vectorMovimientoFinal;

    Animator anim;

    private Vector3 x, y;


     public string tag;
    


	// Use this for initialization
	void Start () {

        sprites = (SpriteRenderer)GetComponent(typeof(SpriteRenderer));
        controller = GetComponent<Rigidbody2D>();
        x = new Vector3(1, 0, 0);
        y = new Vector3(0, 1, 0);
        anim = GetComponent<Animator>();
        		
	}
	
	// Update is called once per frame
	void Update () {

        vectorMovimientoFinal = y * Input.GetAxis("Vertical")  + 
                                x * Input.GetAxis("Horizontal") ;

        controller.velocity = vectorMovimientoFinal * Time.deltaTime * velocidad;

        setAnimations();
        anim.SetInteger("Direccion", setAnimations());


    }

    private int setAnimations() {


        if (Input.GetAxis("Horizontal") > 0) //DERECHA
            return 2;
        else if (Input.GetAxis("Horizontal") < 0) //Izquierda
            return 4;
        else if (Input.GetAxis("Vertical") < 0) //ARRIBA
            return 1;
        else if (Input.GetAxis("Vertical") > 0) //ABAJO
            return 3;
        else
            return 5;    


    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "muro")
            Debug.Log("muro");


    }

    public string GetTag(){
        return tag;
    }


}
