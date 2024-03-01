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

    /*public float jumpScaleY;//
    public float jumpScaleX;//
    public float animationDuration;//*/

    public SOFloat soJumpScaleY;
    public SOFloat soJumpScaleX;
    public SOFloat soAnimationDuration;



    public Ease ease = Ease.OutBack;

    public string boolRun = "Run";
    public string triggerDeath = "Death";
    public Animator anim;
    public float playerSwipeDuration = 0.1f;

    private float _currentSpeed;

    [SerializeField]
    private HealthBase _healthBase;
    private void Awake()
    {
        if (_healthBase != null)
        {
            _healthBase.OnKill += OnPlayerKill;
        }
    }


    void Update()
    {
        Jump();
        Move();
    }

    private void OnPlayerKill()
    {
        _healthBase.OnKill -= OnPlayerKill;
        anim.SetTrigger(triggerDeath);
    }
    private void Move()
    {
       
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = speedRun;
            anim.speed = 1.8f;
        }
        else
        {
            _currentSpeed = speed;
            anim.speed = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-_currentSpeed, rb.velocity.y);
            
            if(transform.rotation.y >= 0)
            {
                //rb.transform.DOScaleX(-1, playerSwipeDuration);
                transform.DOLocalRotate(new Vector3(0, 180, 0), playerSwipeDuration);

            }
            
            anim.SetBool(boolRun, true);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(_currentSpeed, rb.velocity.y);
            
            if(transform.rotation.y <= 180)
            {
                //rb.transform.DOScaleX(1, playerSwipeDuration);
                transform.DOLocalRotate(Vector3.zero, playerSwipeDuration);
            }
           
            anim.SetBool(boolRun, true);
        }
        else
        {
            anim.SetBool(boolRun, false);
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
        rb.transform.DOScaleY(soJumpScaleY.value, soAnimationDuration.value).SetLoops(2,LoopType.Yoyo).SetEase(ease);
        rb.transform.DOScaleX(soJumpScaleX.value, soAnimationDuration.value).SetLoops(2,LoopType.Yoyo).SetEase(ease);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
