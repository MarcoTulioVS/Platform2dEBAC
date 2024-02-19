using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int startLife = 10;

    private int _currentLife;

    private bool _isDead;

    public bool destroyOnKill;

    [SerializeField]
    private float delayToKill;
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _currentLife = startLife;
        _isDead = false;
    }

    public void Damage(int damage)
    {
        if (!_isDead)
        {
            _currentLife -= damage;

            if (_currentLife <= 0)
            {
                Kill();
            }
        }
       
    }

    private void Kill()
    {
        _isDead = true;

        if (destroyOnKill)
        {
            Destroy(gameObject,delayToKill);
        }
    }
}
