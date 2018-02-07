using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_generator : MonoBehaviour {
	public GameObject baldosa;
	public GameObject pared;
	public GameObject pared_top;
	public GameObject suelo;
	public GameObject columna;
	public GameObject [,] sala;
	public GameObject jugador;
	public Camera camara;
	public int dimensionx;
	public int dimensiony;
	private int columnas;
	private int filas;
    private int tag;
	


	// Use this for initialization
	void Start () {
		for(; columnas < dimensionx; columnas++){
			for(;filas < dimensiony;filas++){

				if(columnas == dimensionx || filas == dimensiony || columnas == 0 || filas == 0){

						
						
                        baldosa.layer = 8;
						baldosa.GetComponent<BoxCollider2D>().isTrigger = false;
						if(columnas == 0 ){
							baldosa.GetComponent<SpriteRenderer>().sprite = pared.GetComponent<SpriteRenderer>().sprite;
							if(filas == dimensiony){
								sala[columnas,filas] = Instantiate (baldosa, new Vector2 (columnas,filas),transform.rotation);
							}


						}else if(filas == 0){
							baldosa.GetComponent<SpriteRenderer>().sprite = pared.GetComponent<SpriteRenderer>().sprite;

						}else if(columnas == dimensionx){
							baldosa.GetComponent<SpriteRenderer>().sprite = pared.GetComponent<SpriteRenderer>().sprite;
							if(filas == dimensiony){
								sala[columnas,filas] = Instantiate (baldosa, new Vector2 (columnas,filas),transform.rotation);
							}

						}else if(filas == dimensiony){
							baldosa.GetComponent<SpriteRenderer>().sprite = pared.GetComponent<SpriteRenderer>().sprite;
							sala[columnas,filas] = Instantiate (baldosa, new Vector2 (columnas,filas),transform.rotation);
							baldosa.GetComponent<SpriteRenderer>().sprite = pared_top.GetComponent<SpriteRenderer>().sprite;
						}
                        if(columnas == 0  && filas == 0)
                        {
                            baldosa.tag = "esquina inferior izquierda";
                        }else if(columnas == dimensionx && filas == 0)
                        {
                            baldosa.tag = "esquina inferior derecha";
                        }else if(columnas == 0  && filas == dimensiony)
                        {
                            baldosa.tag = "esquina superior izquierda";
                        }else if(columnas == dimensionx && filas == dimensiony)
                        {
                            baldosa.tag = "esquina superior derecha";
                        }
                        else
                        {
                            baldosa.tag = "muro";
                        }
					

					}else{

						baldosa.GetComponent<SpriteRenderer>().sprite = suelo.GetComponent<SpriteRenderer>().sprite;
						baldosa.tag ="suelo" + tag;
                        baldosa.layer = 9;
						baldosa.GetComponent<BoxCollider2D>().isTrigger = true;

					}
					sala[columnas,filas] = Instantiate (baldosa, new Vector2 (columnas,filas),transform.rotation);
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
