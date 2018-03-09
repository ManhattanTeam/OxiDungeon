using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class control_jugador : MonoBehaviour {
    
    [Range(0,500)]
    public float velocidad;
    SpriteRenderer sprites;
    Rigidbody2D controller;
    Vector2 vectorMovimientoFinal;
    GameObject [] corazonesObj;
    public GameObject Bala;

    public Sprite corazonVacio, corazonLleno;

    Animator anim;

    private Vector3 x, y;

    public int vidas = 5;

	// Use this for initialization
	void Start () {

        sprites = (SpriteRenderer)GetComponent(typeof(SpriteRenderer));
        controller = GetComponent<Rigidbody2D>();
        x = new Vector3(1, 0, 0);
        y = new Vector3(0, 1, 0);
        anim = GetComponent<Animator>();
        corazonesObj = GameObject.FindGameObjectsWithTag("Corazones");


    }

    [Range (50, 1000)]
    public float dashForce;
    private float cuentaAtrasDash = 0;
	
	// Update is called once per frame
	void Update () {

        vectorMovimientoFinal = y * Input.GetAxis("Vertical") +
                                x * Input.GetAxis("Horizontal");

        cuentaAtrasDash -=  Time.deltaTime;

        if (Input.GetButtonDown("Dash") && cuentaAtrasDash <= 0) {

            cuentaAtrasDash = 2;

            //Debug.Log("DASHHHH");

           // controller.velocity = vectorMovimientoFinal * Time.deltaTime * velocidad * 2;
            controller.AddForce(vectorMovimientoFinal * velocidad * 6);
            
        } else
              controller.velocity = vectorMovimientoFinal * Time.deltaTime * velocidad;

        setAnimations();
        anim.SetInteger("Direccion", setAnimations());

        controlDeVidas();

        //Debug.Log("Tengo " + vidas + " vidas");

        if (Input.GetButtonDown("FireRight"))
        {
            Instantiate(Bala, transform.position, Quaternion.Euler(0, 0, 0));
        }
        else if (Input.GetButtonDown("FireUp"))
        {
            Debug.Log("up");
            Instantiate(Bala, transform.position, Quaternion.Euler(0, 0, 90));

        }
        else if (Input.GetButtonDown("FireLeft"))
        {
            Instantiate(Bala, transform.position, Quaternion.Euler(0, 0, 180));
        }
        else if (Input.GetButtonDown("FireDown"))
        {
            Instantiate(Bala, transform.position, Quaternion.Euler(0, 0, 270));
        }


    }

    private void controlDeVidas() {

        int i = 0;
        for (; i < vidas - 1; i++) {
            Image img = corazonesObj[i].GetComponent<Image>();
            img.sprite = corazonLleno;
        }
        for (; i < 5; i++) {

            Image img = corazonesObj[i].GetComponent<Image>();
            img.sprite = corazonVacio;
        }

        if (vidas <= 0)
            Application.Quit();

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
