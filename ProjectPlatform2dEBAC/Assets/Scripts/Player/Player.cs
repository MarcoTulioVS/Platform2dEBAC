using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Player : MonoBehaviour
{
    public Rigidbody2D rb;

    //private float movement;

    [Header("Setup")]

    public SOPlayerSetup soPlayerSetup;
    //public Animator anim;

    private Animator _currentPlayer;
    
    private float _currentSpeed;

    [SerializeField]
    private HealthBase _healthBase;

    public int direction = 1;

    [Header("Jump Collision Check")]
    public Collider2D collider2D;
    private float distToGround;
    public float spaceToGround = 0.1f;
    public ParticleSystem jumpVFX;

    
    private void Awake()
    {
        if (_healthBase != null)
        {
            _healthBase.OnKill += OnPlayerKill;
        }

        _currentPlayer = Instantiate(soPlayerSetup.player,transform);

        if(collider2D != null)
        {
            distToGround = collider2D.bounds.extents.y;
        }
    }

    private bool isGrounded()
    {
        //Debug.DrawRay(transform.position, -Vector2.up, Color.magenta, distToGround + spaceToGround);
        return Physics2D.Raycast(transform.position, -Vector2.up, distToGround + spaceToGround);
    }

    void Update()
    {
        
        Jump();
        Move();
    }

    private void OnPlayerKill()
    {
        _healthBase.OnKill -= OnPlayerKill;
        _currentPlayer.SetTrigger(soPlayerSetup.triggerDeath);
    }
    private void Move()
    {
       
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = soPlayerSetup.speedRun;
            _currentPlayer.speed = 1.8f;
        }
        else
        {
            _currentSpeed = soPlayerSetup.speed;
            _currentPlayer.speed = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-_currentSpeed, rb.velocity.y);
            
            if(transform.rotation.y >= 0)
            {
                //rb.transform.DOScaleX(-1, playerSwipeDuration);
                transform.DOLocalRotate(new Vector3(0, 180, 0), soPlayerSetup.playerSwipeDuration);
                direction = -1;
            }

            _currentPlayer.SetBool(soPlayerSetup.boolRun, true);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(_currentSpeed, rb.velocity.y);
            
            if(transform.rotation.y <= 180)
            {
                //rb.transform.DOScaleX(1, playerSwipeDuration);
                transform.DOLocalRotate(Vector3.zero, soPlayerSetup.playerSwipeDuration);
                direction = 1;
            }

            _currentPlayer.SetBool(soPlayerSetup.boolRun, true);
        }
        else
        {
            _currentPlayer.SetBool(soPlayerSetup.boolRun, false);
        }


        if(rb.velocity.x > 0)
        {
            rb.velocity -= soPlayerSetup.friction;
        }
        else if(rb.velocity.x < 0)
        {
            rb.velocity += soPlayerSetup.friction;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.velocity = Vector2.up * soPlayerSetup.jumpForce;
            rb.transform.localScale = Vector2.one;

            DOTween.Kill(rb.transform);
            ScaleJump();
            PlayJumpVFX();
        }
    }

    private void PlayJumpVFX()
    {
        VFXManager.instance.PlayVFXByType(VFXManager.VFXType.JUMP, transform.position);
        //if (jumpVFX != null)
        //{
        //    jumpVFX.Play();
        //}
    }

    private void ScaleJump()
    {
        rb.transform.DOScaleY(soPlayerSetup.jumpScaleY, soPlayerSetup.animationDuration).SetLoops(2,LoopType.Yoyo).SetEase(soPlayerSetup.ease);
        rb.transform.DOScaleX(soPlayerSetup.jumpScaleX, soPlayerSetup.animationDuration).SetLoops(2,LoopType.Yoyo).SetEase(soPlayerSetup.ease);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
