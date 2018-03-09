using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room : MonoBehaviour
{

    private GameObject[,] sala;
    private int dimensionX;
    private int dimensionY;
    private BoxCollider2D ColliderSala;

    // Use this for initialization
    void Start()
    {
        ColliderSala = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {


    }
    public void GetSala(GameObject[,] sala, int dimensionX, int dimensionY)
    {

        this.sala = new GameObject[dimensionX, dimensionY + 1];
        //this.sala = sala;
        this.dimensionX = dimensionX;
        this.dimensionY = dimensionY;
        for (int x = 0; x < this.dimensionX; x++)
        {
            for (int y = 0; y < this.dimensionY; y++)
            {
                this.sala[x, y] = sala[x, y];
               // Debug.Log(this.sala[x, y]);

            }
        }


    }
    public Vector2 MoveSala(Vector2 vector)
    {
        transform.position = new Vector2(transform.position.x, transform.position.y) + vector;

        return vector = new Vector2(transform.position.x, transform.position.y);

    }

    public void DestroySala()
    {
        Destroy(sala[1, 1]);
        for (int x = 0; x < dimensionX; x++)
        {
            for (int y = 0; y < dimensionY; y++)
            {
                Destroy(sala[x, y]);

            }
        }

    }
    public Vector2 GetVectorSala()
    {
        return new Vector2(dimensionX, dimensionY);
    }

}