using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room{
	private GameObject [,] sala;
	public void Getsala(GameObject[,]sala){
		this.sala = sala;

	}
}
public class map_generator : MonoBehaviour {
	public GameObject baldosa;
	public Sprite pared;
	public Sprite pared_top;
	public Sprite suelo;
	public Sprite columna;
	public GameObject [,] sala;
	public GameObject jugador;
	public Camera camara;
	private room [] rooms;
	int dimensionx = 10;
	int dimensiony = 10;
	int columnas = 0;
	int filas = 0;
	int auxX=0;
	int auxY=0;
    private int tag=0;
	
   
	// Use this for initialization
	void Start () {
		rooms = new room[1]; 
		sala = new GameObject[dimensionx,dimensiony];
		for(; columnas < dimensionx; columnas++){
			for(;filas < dimensiony;filas++){
				if(columnas == 0 + auxX || filas == 0 + auxY || columnas == (dimensionx + auxX) - 1 || filas == (dimensiony + auxY) - 1){

                        baldosa.layer = 8;
						baldosa.GetComponent<BoxCollider2D>().isTrigger = false;
						if(columnas == 0 + auxX){
							baldosa.GetComponent<SpriteRenderer>().sprite = pared;
                            sala[columnas, filas] = Instantiate(baldosa, new Vector2(columnas, filas), transform.rotation);

                        }else if (filas == (dimensiony + auxY)){
                            baldosa.GetComponent<SpriteRenderer>().sprite = pared;
                            sala[columnas,filas] = Instantiate (baldosa, new Vector2 (columnas,filas),transform.rotation);

						}else if(filas == 0 + auxY){
							baldosa.GetComponent<SpriteRenderer>().sprite = pared;

						}else if(columnas == (dimensionx + auxX)){
							baldosa.GetComponent<SpriteRenderer>().sprite = pared;
							if(filas == (dimensiony + auxY)){
								sala[columnas,filas] = Instantiate (baldosa, new Vector2 (columnas,filas),transform.rotation);
							}

						}else if(filas == (dimensiony + auxY)){
							baldosa.GetComponent<SpriteRenderer>().sprite = pared;
							sala[columnas,filas] = Instantiate (baldosa, new Vector2 (columnas,filas),transform.rotation);
							baldosa.GetComponent<SpriteRenderer>().sprite = pared_top;
						}
                        if(columnas == 0 + auxX && filas == 0 + auxY)
                        {
                            baldosa.tag = "esquina inferior izquierda";
                        }else if(columnas == dimensionx + auxX - 1 && filas == 0 + auxY)
                        {
                            baldosa.tag = "esquina inferior derecha";
                        }else if(columnas == 0 + auxX && filas == dimensiony + auxY - 1)
                        {
                            baldosa.tag = "esquina superior izquierda";
                        }else if(columnas == dimensionx + auxX - 1 && filas == dimensiony + auxY - 1)
                        {
                            baldosa.tag = "esquina superior derecha";
                        }
                        else
                        {
                            baldosa.tag = "muro";
                        }
					

					}else{

						baldosa.GetComponent<SpriteRenderer>().sprite = suelo;
						baldosa.tag ="suelo" + tag;
                        baldosa.layer = 9;
						baldosa.GetComponent<BoxCollider2D>().isTrigger = true;

					}
				
				sala[columnas,filas] = Instantiate (baldosa, new Vector2 (columnas,filas),transform.rotation);
			}
			filas = 0;
		}
		rooms[0].Getsala(sala);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
