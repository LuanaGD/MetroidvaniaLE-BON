using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Threading;
using UnityEngine;

public class LTN_PlayerMoveScript : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    public Rigidbody2D rb;
    public Collider2D jumpVerify;
    [SerializeField]
    bool jump = false;

    Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
