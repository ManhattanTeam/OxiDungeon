using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_generator : MonoBehaviour {
	public GameObject baldosa;
	public Sprite pared;
	public Sprite pared_top;
	public Sprite suelo;
	public Sprite columna;
	public GameObject [,] sala;
	public GameObject jugador;
	public Camera camara;
	int dimensionx = 10;
	int dimensiony = 10;
	int columnas = 0;
	int filas = 0;
    private int tag;
	


	// Use this for initialization
	void Start () {
		sala = new GameObject[dimensionx,dimensiony];
		for(; columnas < dimensionx; columnas++){
			for(;filas < dimensiony;filas++){
				
				sala[columnas,filas] = Instantiate (baldosa, new Vector2 (columnas,filas),transform.rotation);
			}
			filas = 0;
		}

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
