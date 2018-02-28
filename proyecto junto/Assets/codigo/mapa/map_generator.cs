using System;
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
    public GameObject Room;
	private room [] rooms;
    public GameObject[] Rooms;
    int nsalas;
	int dimensionx = 30;
	int dimensiony = 10;
	int columnas = 0;
	int filas = 0;
	int auxX=0;
	int auxY=0;
    private int tag=0;


    // Use this for initialization
    void Start()
    {
        //nsalas = UnityEngine.Random.Range(5,9);
        nsalas = 1;
        rooms = new room[nsalas];
        Rooms = new GameObject[nsalas]; 
        
        for(int i = 0;i < nsalas;i++){
            //dimensionx = UnityEngine.Random.Range(9,37);
            //dimensiony = UnityEngine.Random.Range(9,37);
            sala = new GameObject[dimensionx, dimensiony + 1];
            Rooms[0] = Instantiate(Room,new Vector2(auxX,auxY),transform.rotation);
            rooms[0] = Rooms[0].GetComponent<room>();

        
            for (; columnas < dimensionx; columnas++)
            {
                for (; filas < dimensiony; filas++)
                {
                    if (columnas == 0 + auxX || filas == 0 + auxY || columnas == (dimensionx + auxX) - 1 || filas == (dimensiony + auxY) - 1)
                    {

                        baldosa.layer = 8;
                        baldosa.GetComponent<BoxCollider2D>().isTrigger = false;
                        if (columnas == 0 + auxX)
                        {
                            baldosa.GetComponent<SpriteRenderer>().sprite = pared;

                        }
                        else if (filas == (dimensiony + auxY) - 1 && (columnas != 0 + auxX && columnas != (dimensionx - 1) + auxX))
                        {
                            baldosa.GetComponent<SpriteRenderer>().sprite = pared;
                            sala[columnas, filas + 1] = Instantiate(baldosa, new Vector2(columnas, filas + 1), transform.rotation);
                            sala[columnas,filas + 1].transform.parent = Rooms[0].transform;
                            baldosa.GetComponent<SpriteRenderer>().sprite = pared_top;

                        }
                        else if (filas == 0 + auxY)
                        {
                            baldosa.GetComponent<SpriteRenderer>().sprite = pared;

                        }
                        else if (columnas == (dimensionx + auxX) - 1)
                        {
                            baldosa.GetComponent<SpriteRenderer>().sprite = pared;

                        }
                        if (columnas == 0 + auxX && filas == 0 + auxY)
                        {
                            baldosa.tag = "esquina inferior izquierda";
                        }
                        else if (columnas == dimensionx + auxX - 1 && filas == 0 + auxY)
                        {
                            baldosa.tag = "esquina inferior derecha";
                        }
                        else if (columnas == 0 + auxX && filas == dimensiony + auxY - 1)
                        {
                            baldosa.tag = "esquina superior izquierda";
                        }
                        else if (columnas == dimensionx + auxX - 1 && filas == dimensiony + auxY - 1)
                        {
                            baldosa.tag = "esquina superior derecha";
                        }
                        else
                        {
                            baldosa.tag = "muro";
                        }


                    }
                    else
                    {

                        baldosa.GetComponent<SpriteRenderer>().sprite = suelo;
                        baldosa.tag = "suelo" + tag;
                        baldosa.layer = 9;
                        baldosa.GetComponent<BoxCollider2D>().isTrigger = true;

                    }

                    sala[columnas, filas] = Instantiate(baldosa, new Vector2(columnas, filas), transform.rotation);
                    sala[columnas,filas].transform.parent = Rooms[0].transform;
                }
                filas = 0;
            }
        
            rooms[0].GetSala(sala,dimensionx,dimensiony);
            sala = null;
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
    
}
