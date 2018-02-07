using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour {
	private GameObject jugador;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		jugador = GameObject.FindWithTag("jugador");

		this.gameObject.transform.position = new Vector3(jugador.transform.position.x , jugador.transform.position.y, -10);
		
	}
}
