using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
    public Animator player;
    public SOString soStringName;

    [Header("Speed setup")]
    public Vector2 friction = new Vector2(0.3f,0);

    public float speed;
    public float speedRun;

    
    public float jumpForce;


    public float jumpScaleY;
    public float jumpScaleX;
    public float animationDuration;

    public Ease ease = Ease.OutBack;

    public string boolRun = "Run";
    public string triggerDeath = "Death";
    public float playerSwipeDuration = 0.1f;
}
