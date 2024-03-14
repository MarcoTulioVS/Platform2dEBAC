using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;

    public Animator anim;
    public string triggerAttack = "attack";
    public string triggerDeath = "death";

    public HealthBase healthBase;

    public float timeToDestroy;

    public AudioSource audioSourceKill;

    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnEnemyKill;
        }
    }

    private void OnEnemyKill()
    {
        healthBase.OnKill -= OnEnemyKill;
        PlayDeathAnimation();

        if(audioSourceKill != null)
        {
            audioSourceKill.Play();
        }

        Destroy(gameObject,timeToDestroy);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<HealthBase>();

        if(health != null)
        {
            health.Damage(damage);
            PlayAttackAnimation();
        }
    }

    private void PlayAttackAnimation()
    {
        anim.SetTrigger(triggerAttack);
    }
    private void PlayDeathAnimation()
    {
        anim.SetTrigger(triggerDeath);
    }

    public void Damage(int amount)
    {
        healthBase.Damage(amount);
    }

}
