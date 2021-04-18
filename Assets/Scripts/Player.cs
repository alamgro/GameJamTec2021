using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * By Alam Rodriguez.
 * This script contains the player logic for movement, jumping, the souls counter, and animations.
 * April 17th 2021.
 */
public class Player : MonoBehaviour
{
    #region PUBLIC VARIABLES
    [Header("Player config")]
    public float walkSpeed; //Velocidad de movimiento
    public float jumpForce; //Fuerza de salto
    public LayerMask raycastMask; //Esta LayerMask toma en cuenta a todas las layers menos la del player.
    public Transform groundChecker;
    [Header("Gameplay parameters")]
    #endregion

    #region PRIVATE VARIABLES
    private float currentSpeed;
    private float horizontalMove;
    private float distanceToGround; //Guarda el tama�o de nuestro collider para calcular la distancia del player al piso
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
        anim = GetComponent<Animator>();
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
    }

    private void Jump()
    {
        //Saltar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Checar posici�n de los pies para saber si puedes brincar
            if (IsGrounded())
            {
                anim.Play("Jump"); //Forzar animaci�n de salto
                velRb.y = jumpForce; //Dar velocidad al eje Y para saltar
            }
        }
    }

    private void ManageSprite()
    {
        anim.SetFloat("VelX", Mathf.Abs(horizontalMove)); //Mandar al animador la velocidad horizontal (X) actual

        anim.SetFloat("VelY", rb.velocity.y); //Le hago saber a la animaci�n cu�l es la velocidad en Y del personaje

        //Hacer flip a la animaci�n dependiendo de la direcci�n a la que camine en el eje X
        if (horizontalMove > 0.1f) //Cuando va a la derecha
            spritePlayer.flipX = false;
        else if (horizontalMove < -0.1f) //Cuanda va a la izquierda
            spritePlayer.flipX = true;
    }

}

