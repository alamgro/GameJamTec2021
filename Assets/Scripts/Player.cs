using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region PUBLIC VARIABLES
    [Header("Player config")]
    public float walkSpeed; //Velocidad de movimiento
    public float jumpForce; //Fuerza de salto
    public LayerMask raycastMask; //Esta LayerMask toma en cuenta a todas las layers menos la del player.
    public Transform groundChecker;
    #endregion

    #region PRIVATE VARIABLES
    private float currentSpeed;
    private float horizontalMove;
    private float distanceToGround; //Guarda el tamaño de nuestro collider para calcular la distancia del player al piso
    private Rigidbody2D rb;
    private Vector2 velRb;
    private SpriteRenderer spritePlayer;
    private Animator anim;
    #endregion

    void Start()
    {
        #region GET COMPONENTS
        rb = GetComponent<Rigidbody2D>();
        spritePlayer = GetComponent<SpriteRenderer>();
        //anim = GetComponent<Animator>();
        #endregion

        #region VARIABLES INIT
        currentSpeed = walkSpeed;
        distanceToGround = GetComponent<Collider2D>().bounds.extents.y;
        #endregion
    }

    void Update()
    {
        velRb = rb.velocity; //Guardar temporalmente el velocity del RigidBody
        currentSpeed = walkSpeed; //Dar una velocidad por defecto al jugador

        Jump();
        Movement();
        ManageSprite();

        rb.velocity = velRb; //Asignar la velocidad final al rigidbody
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(groundChecker.position, new Vector2(distanceToGround, 0.1f), 0f,Vector2.down, 0.1f, raycastMask); //Lanzar rayo para detectar el piso
        //return Physics2D.Raycast(transform.position, Vector2.down, distanceToGround + 0.1f, raycastMask); //Lanzar rayo para detectar el piso
    }


    private void Movement()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * currentSpeed; //Guardar el valor del input de movimiento horizontal
        velRb.x = horizontalMove; //Asignar al RigidBody velocidad en X para que se mueva
        //anim.SetFloat("VelX", Mathf.Abs(horizontalMove)); //Mandar al animador la velocidad horizontal actual
    }

    private void Jump()
    {
        //Saltar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Checar posición de los pies para saber si puedes brincar
            if (IsGrounded())
            {
                velRb.y = jumpForce; //Dar velocidad al eje Y para saltar
            }
        }
    }

    private void ManageSprite()
    {
        //Hacer flip a la animación dependiendo de la dirección a la que camine en el eje X
        if (horizontalMove > 0.1f) //Cuando va a la derecha
            spritePlayer.flipX = false;
        else if (horizontalMove < -0.1f) //Cuanda va a la izquierda
            spritePlayer.flipX = true;
    }

}

