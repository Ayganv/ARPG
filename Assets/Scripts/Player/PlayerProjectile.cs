using System.Collections;
using System.Collections.Generic;
using EnemyScripts;
using Player;
using UnityEngine;


public class PlayerProjectile : MonoBehaviour
{
    public float Speed;

    [Space]
    public float secondsUntilDestroy = 1.5f;
    public int Damage;
    private Vector3 _target;
    private float timer;
    

    private void Awake()
    {
        _target = PlayerManager.Instance.RangedAttack.targetPos;
        transform.LookAt(_target);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        Move();
        DestroyAfterTime();
    }

    public void Move()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        
       if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Respawn") && !other.gameObject.CompareTag("Projectile"))
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("RangedEnemy"))
        {
           other.gameObject.GetComponentInParent<EvilPlantHealth>().TakeDamage(Damage);
           Destroy(this.gameObject);
        }
            
    }

    public void DestroyAfterTime()
    {
        if (timer >= secondsUntilDestroy)
        {
            Destroy(gameObject);
        }
    }
}
