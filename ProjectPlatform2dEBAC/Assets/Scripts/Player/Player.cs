using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField]
    private Vector2 friction;

    public float speed;

    private float movement;

    [SerializeField]
    private float jumpForce;
    void Start()
    {
        
    }

    
    void Update()
    {
        Jump();
        Move();
    }

    private void Move()
    {
        //movement = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector2(speed * movement,rb.velocity.y);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }


        if(rb.velocity.x > 0)
        {
            rb.velocity -= friction;
        }
        else if(rb.velocity.x < 0)
        {
            rb.velocity += friction;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        
    }
}
