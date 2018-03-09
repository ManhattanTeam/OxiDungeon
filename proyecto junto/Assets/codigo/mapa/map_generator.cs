using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_generator : MonoBehaviour
{
    public GameObject baldosa;
    public Sprite pared;
    public Sprite pared_top;
    public Sprite suelo;
    public Sprite columna;
    public GameObject[,] sala;
    public GameObject jugador;
    public Camera camara;
    public GameObject Room;
    private room[] rooms;
    public GameObject[] Rooms;
    int nsalas;
    int dimensionx = 30;
    int dimensiony = 10;
    int columnas = 0;
    int filas = 0;
    int auxX = 0;
    int auxY = 0;


    // Use this for initialization
    void Awake()
    {
        //nsalas = UnityEngine.Random.Range(5,6);
        nsalas = 1;
        rooms = new room[nsalas];
        Rooms = new GameObject[nsalas];

        for (int i = 0; i < nsalas; i++)
        {

            sala = new GameObject[dimensionx, dimensiony + 1];
            Rooms[i] = Instantiate(Room, new Vector2(0, 0), transform.rotation);
            rooms[i] = Rooms[i].GetComponent<room>();


            for (; columnas < dimensionx; columnas++)
            {
                for (; filas < dimensiony; filas++)
                {
                    if (columnas == 0 || filas == 0 || columnas == dimensionx - 1 || filas == dimensiony - 1)
                    {

                        baldosa.layer = 8;
                        baldosa.GetComponent<BoxCollider2D>().isTrigger = false;
                        if (columnas == 0)
                        {
                            baldosa.GetComponent<SpriteRenderer>().sprite = pared;

                        }
                        else if (filas == dimensiony - 1 && (columnas != 0 && columnas != dimensionx - 1))
                        {
                            baldosa.GetComponent<SpriteRenderer>().sprite = pared;
                            sala[columnas, filas + 1] = Instantiate(baldosa, new Vector2(columnas, filas + 1), transform.rotation);
                            sala[columnas, filas + 1].transform.parent = Rooms[i].transform;
                            baldosa.GetComponent<SpriteRenderer>().sprite = pared_top;

                        }
                        else if (filas == 0)
                        {
                            baldosa.GetComponent<SpriteRenderer>().sprite = pared;

                        }
                        else if (columnas == dimensionx - 1)
                        {
                            baldosa.GetComponent<SpriteRenderer>().sprite = pared;

                        }
                        if (columnas == 0 && filas == 0)
                        {
                            baldosa.tag = "esquina inferior izquierda";
                        }
                        else if (columnas == dimensionx - 1 && filas == 0)
                        {
                            baldosa.tag = "esquina inferior derecha";
                        }
                        else if (columnas == 0 && filas == dimensiony - 1)
                        {
                            baldosa.tag = "esquina superior izquierda";
                        }
                        else if (columnas == dimensionx - 1 && filas == dimensiony - 1)
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
                        baldosa.tag = "suelo" + i;
                        baldosa.layer = 9;
                        baldosa.GetComponent<BoxCollider2D>().isTrigger = true;

                    }

                    sala[columnas, filas] = Instantiate(baldosa, new Vector2(columnas, filas), transform.rotation);
                    sala[columnas, filas].transform.parent = Rooms[i].transform;
                }
                filas = 0;
            }
            rooms[i].GetSala(sala, dimensionx, dimensiony);
            sala = null;
            dimensionx = UnityEngine.Random.Range(9, 37);
            dimensiony = UnityEngine.Random.Range(9, 37);
            columnas = 0;
            filas = 0;
        }
        //MoveSala();
        Instantiate(jugador, Rooms[0].transform.position + new Vector3(dimensionx / 2, dimensiony / 2, -1), transform.rotation);
        Instantiate(camara, jugador.transform.position, transform.rotation);
        camara.transform.parent = jugador.transform;

    }

    // Update is called once per frame
    void Update()
    {

    }
    void MoveSala()
    {
        int PositionRoom;
        Vector2 vector = new Vector2(0, 0);
        for (int x = 0; x < nsalas; x++)
        {
            PositionRoom = UnityEngine.Random.Range(0, 5);
            switch (PositionRoom)
            {
                case 0:
                    vector = rooms[x].MoveSala(vector) + rooms[x].GetVectorSala();
                    break;
                case 1:
                    vector = rooms[x].MoveSala(vector) - new Vector2(40, 40) + new Vector2(-1, 0);
                    break;
                case 2:
                    vector = rooms[x].MoveSala(vector) + rooms[x].GetVectorSala() + new Vector2(1, 0);
                    break;
                case 3:
                    vector = rooms[x].MoveSala(vector) + rooms[x].GetVectorSala() + new Vector2(0, 1);
                    break;
                case 4:
                    vector = rooms[x].MoveSala(vector) - new Vector2(40, 40) + new Vector2(0, -1);
                    break;


            }


        }
    }

}