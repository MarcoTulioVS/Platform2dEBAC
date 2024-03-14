using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;

    public Transform positionToShoot;

    public float timeBetweenShoot = 0.3f;

    private Coroutine _currentCoroutine;

    public Player playerSideReference;

    public AudioRandomPlayAudioClips randomShoot;

    private void Awake()
    {
       
        playerSideReference = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }
        }
    }

    public void Shoot()
    {
        if (randomShoot != null)
        {
            randomShoot.PlayRandom();
        }

        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        //projectile.side = playerSideReference.transform.localScale.x;
        projectile.side = playerSideReference.direction;
        VFXManager.instance.PlayVFXByType(VFXManager.VFXType.SHOOT,positionToShoot.position);
    }

    IEnumerator StartShoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }
}
