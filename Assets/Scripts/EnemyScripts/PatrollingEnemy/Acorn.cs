using System;
using Player;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    public float Speed;

    [Space]
    public int Damage;

    public Vector3 target;
    private float timer;
    public float secondsUntilDestroy = 8;
    public bool projectile;

    private void Awake(){
        var playerHealth = PlayerManager.Instance.PlayerHealth;
        
        if(playerHealth!=null)
            target = playerHealth.transform.position;
        
        if (projectile && target != null)
        {
            transform.LookAt(target);
        }
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
        if (!other.gameObject.CompareTag("RangedEnemy"))
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            PlayerManager.Instance.PlayerHealth.TakeDamage(Damage);
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