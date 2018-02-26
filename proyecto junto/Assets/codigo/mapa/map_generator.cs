using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room : MonoBehaviour {
	private GameObject [,] sala;
    private int dimensionX;
    private int dimensionY;
	public void GetSala(GameObject[,]sala,int dimenisonX,int dimensionY){
		this.sala = sala;
        this.dimensionX = dimenisonX;
        this.dimensionY = dimensionY;

	}
    public void DestroySala()
    {
        for (int x = 0; x < dimensionX; x ++)
        {
            for (int y = 0; y < dimensionY; y++)
            {
                Destroy(sala[x, y]);

            }
        }

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
    void Start()
    {
        rooms = new room[1];
        sala = new GameObject[dimensionx, dimensiony + 1];
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
            }
            filas = 0;
        }
        rooms[0].GetSala(sala,dimensionx,dimensiony);
        sala = null;
        rooms[0].DestroySala();

    }

    // Update is called once per frame
    void Update () {
		
	}
    
}
