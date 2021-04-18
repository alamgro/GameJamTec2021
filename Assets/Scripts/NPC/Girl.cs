using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour
{
    /* Lo tendran las niñas que te siguen
     * Alexander Iñiguez
     * 
     */

    private GameObject player; 
   // public Transform posMin;
   // public Transform posMax;

    private Rigidbody2D rb;

    public float force;
    public float distancia;

    //private float time;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //tomamos el player
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        //if (Vector3.Distance(target.position, objectToMove.position) > 0.5f) //distancia entre el objeto y player

            if(Vector3.Distance(transform.position, player.transform.position) < distancia)
            {
                Follow();
            }
    }

    public void Follow()
    {
        if(transform.position.x < player.transform.position.x)//Detecta la derecha
        {
            rb.velocity = new Vector2(force, rb.velocity.y); //derecha
        }
        else 
        {
            rb.velocity = new Vector2(-force, rb.velocity.y); //Izquierda
        }
    }
}
