using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public Transform[] pos;
    private int index;
    private int temp;
    [InspectorName("Distancia al player")]
    private float time;
    private float timeOut;
    public  float velToMoving;
    private bool isMoving;

    void Start()
    {
        isMoving = true;
        time = 0; //reset time
        //player = GameObject.FindGameObjectWithTag("Player"); //tomamos el player
        //rb = GetComponent<Rigidbody2D>();
        timeOut = Random.Range(1.0f, 6.1f);
        index = Random.Range(0, pos.Length);
        temp = index;
    }

    void Update()
    {
        time += Time.deltaTime; //llenamos el tiempo

       // if (Vector3.Distance(transform.position, pos[index].transform.position) == 0.0f)
       if(transform.position == pos[index].transform.position)
            isMoving = false;

        if (timeOut <= time)
        {
            Move(); 
            if(!isMoving)
            {
                ResetParameters();

            }
        }
    }

    private void Move()//mueve el personaje a la nueva posciosion
    {
        transform.position = Vector2.MoveTowards(transform.position, pos[index].transform.position, velToMoving * Time.deltaTime);
    }
        
    private void ResetParameters()//genera un nuevo tiempo y poscision
    {
        
        time = 0; //reset time
        isMoving = true;
        timeOut = Random.Range(1.1f, 6.1f);
        do
        {
            index = Random.Range(0, pos.Length);
            
        } while (temp == index);
        temp = index; //termine con el valor anterior
    }
}
