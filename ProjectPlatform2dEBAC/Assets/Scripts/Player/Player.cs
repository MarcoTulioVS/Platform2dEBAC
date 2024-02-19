using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Player : MonoBehaviour
{
    public Rigidbody2D rb;

    [Header("Speed setup")]
    [SerializeField]
    private Vector2 friction;

    public float speed;
    public float speedRun;

    [SerializeField]
    private float jumpForce;

    //private float movement;

    [Header("Animation setup")]

    public float jumpScaleY;
    public float jumpScaleX;
    public float animationDuration;
    public Ease ease = Ease.OutBack; 

    private float _currentSpeed;
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

        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = speedRun;
        }
        else
        {
            _currentSpeed = speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-_currentSpeed, rb.velocity.y);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(_currentSpeed, rb.velocity.y);
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
            rb.transform.localScale = Vector2.one;

            DOTween.Kill(rb.transform);
            ScaleJump();
        }
    }

    private void ScaleJump()
    {
        rb.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2,LoopType.Yoyo).SetEase(ease);
        rb.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2,LoopType.Yoyo).SetEase(ease);
    }
}
