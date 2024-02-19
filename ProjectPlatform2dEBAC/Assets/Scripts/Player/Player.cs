using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;

    public Vector2 velocity;

    public float speed;

    private float movement;
    void Start()
    {
        
    }

    
    void Update()
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
    }
}
