using UnityEngine;
using System.Collections;

public class Explosionador : MonoBehaviour
{

    // Use this for initialization
    private GameObject player;
    private Vector3 player_position;
    public float velocity;
    private bool vision;

    public void posicion_jugador()
    {

        player_position.x = player.transform.position.x;
        player_position.y = player.transform.position.y;

    }

    // Use this for initialization
    void Start()
    {

        player = GameObject.FindWithTag("jugador");
        if (player) Debug.Log("Player encontrado");
        player_position.x = player.transform.position.x;
        player_position.y = player.transform.position.y;

    }

    public LayerMask mask;
    public GameObject rayo;

    bool BdeteccionEnemigo()
    {

        RaycastHit2D vision = Physics2D.Raycast(transform.position, transform.up, 20, mask);
        //Debug.DrawLine(transform.position, rayo.transform.position, Color.green);


        if (vision)
        {
            if (vision.collider.gameObject.tag == "jugador")
            {
                Debug.Log("jugador");
                return true;
            }
            else
            {
                Debug.Log(vision.collider.gameObject.tag);
                return false;
            }

        }

        return false;


    }

    float velocidad = 1;
    bool vivo = true;
    Vector3 ExplotePos;
    void Update()
    {
        if (vivo)
        {
            ExplotePos = transform.position;
            velocidad = 0;
        }
        
        if (BdeteccionEnemigo())
        {
            Debug.Log("ENEMIGO ENCOTRADO");
            posicion_jugador();
            ExplotePos = player_position;
            vivo = false;
            
        }

        
        Debug.Log(velocidad);
        velocidad += 0.2f;
        if (ExplotePos == transform.position && vivo == false) Destroy(this.gameObject);
        transform.position = Vector2.MoveTowards(transform.position, ExplotePos, (velocity*velocidad) * Time.deltaTime);
    }
}
