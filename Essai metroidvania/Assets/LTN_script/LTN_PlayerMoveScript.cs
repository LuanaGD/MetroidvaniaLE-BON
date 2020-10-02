using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design.Serialization;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class LTN_PlayerMoveScript : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;
    private float moveInput;
    [SerializeField]
    private bool facingRight = true;
    [SerializeField]
    private float dashDistance;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        //permet de récupérer le rigidbody pour s'en servir plus loin
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        //saut joueur
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void FixedUpdate()
    {
        //check si player touche le sol pour sauter
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        //bouger le joueur
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        //flip le sprite selon la direction ou le joueur va
        if(facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if(facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    //fonction de flip
    void Flip()
    {
       
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }
}
