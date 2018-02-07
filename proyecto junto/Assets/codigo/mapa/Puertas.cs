using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour {
	private string tag;
	public control_jugador jugador = new control_jugador();
	

	// Use this for initialization
	
	public void AbrirPuerta(){
		GetComponent<BoxCollider2D>().isTrigger = true;
		GetComponent<SpriteRenderer>().color = new Color (0,255,255);

	}
	public void CerrarPuerta(){
		GetComponent<BoxCollider2D>().isTrigger = false;
		GetComponent<SpriteRenderer>().color = new Color (225,0,0);
	}
	void Start () {
		GetComponent<SpriteRenderer>().color = new Color (225,0,0);
		tag = jugador.GetTag();
	
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if (Input.GetKey(KeyCode.N)) {
			AbrirPuerta();
			tag = jugador.GetTag();
			
			

		}
		;
		if(string.Compare(tag,jugador.GetTag()) != 0){
			CerrarPuerta();
			

		}
		
	}
}
