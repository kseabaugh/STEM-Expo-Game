using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    public float jumpForce;

    private bool canInput = true;

    [HideInInspector]
    public Rigidbody2D playerRB;

    //Ground check
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayers;

    private bool facingRight = true;

    private float movementInput;

    private SpriteRenderer playerGraphics;

    private Animator anim;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerGraphics = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //checks if the player isGrounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayers);

        movementInput = Input.GetAxisRaw("Horizontal");

        //Horizontal Movement 
        if (canInput)
        playerRB.velocity = new Vector2(movementInput * speed, playerRB.velocity.y);

        if (movementInput == 0)
        {
            anim.SetBool("isMoving", false);
        }

        else
        {
            anim.SetBool("isMoving", true);
        }

        
        //Graphic flip
        if (facingRight == false && movementInput > 0)
        {
            Flip();
        }

        else if (facingRight == true && movementInput < 0)
        {
            Flip();
        }

    }

    void Update()
    {
        // Jump Inputs
        if (Input.GetButtonDown("Jump") && isGrounded && canInput)
        {
            Jump();
        }

        if (!isGrounded)
        {
            anim.SetBool("isJumping", true);
        }

        else
        {
            anim.SetBool("isJumping", false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }

    }

    void Jump()
    {
        playerRB.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }

    void Attack()
    {
        anim.SetTrigger("attack");
    }

    void JumpAttack()
    {
        anim.SetTrigger("jumpAttack");
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = playerGraphics.transform.localScale;
        Scaler.x *= -1;
        playerGraphics.transform.localScale = Scaler;
    }

}

