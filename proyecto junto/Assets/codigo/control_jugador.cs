using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_jugador : MonoBehaviour {
    
    [Range(0,100)]
    public float velocidad;
    Rigidbody2D rb;
    SpriteRenderer sprites;
    float horizontal;
    float vertical;

     public string tag;
    
	

	// Use this for initialization
	void Start () {
        sprites = (SpriteRenderer)GetComponent(typeof(SpriteRenderer));
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.forward * velocidad;

		
	}
	
	// Update is called once per frame
	void Update () {
        vertical =  Input.GetAxis("Vertical") * velocidad * Time.deltaTime;
        horizontal = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;

        if (Input.GetKey(KeyCode.D)) {
            transform.position += new Vector3(velocidad * Time.deltaTime, 0);
            sprites.flipX = false;
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.position -= new Vector3(velocidad * Time.deltaTime, 0);
            sprites.flipX = true;
        }
        if (Input.GetKey(KeyCode.W)) {
            transform.position += new Vector3(0, velocidad * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.position -= new Vector3(0, velocidad * Time.deltaTime);
        }
		
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        for (int n = 0; n < 9; n++)
        {
            if (collision.tag == "suelo" + n)
            {
                tag = "suelo" + n;
               // Debug.Log("estas en la sala: " + n);
            }

        }

    }
    public string GetTag(){
        return tag;
    }


}
