using System;
using Player;
using UnityEngine;
using UnityEngine.Events;

public class Acorn : MonoBehaviour
{
    public float speed;
    public bool followingProjectile;
    private Transform player;

    [Space] public int Damage;

    public Vector3 target;
    private float timer;
    public float secondsUntilDestroy = 8;
    public bool projectile;

    public UnityEvent startFollowing;
    public UnityEvent stopFollowing;
    private void Awake()
    {
        var playerHealth = PlayerManager.Instance.PlayerHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (playerHealth != null)
            target = playerHealth.transform.position;

        if (projectile && target != null)
        {
            transform.LookAt(target);
        }
        if(followingProjectile)
            startFollowing.Invoke();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        Move();
        DestroyAfterTime();
    }

    public void Move()
    {
        if (followingProjectile == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (followingProjectile == false)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("RangedEnemy") && !other.gameObject.CompareTag("Projectile"))
        {
            Destroy(this.gameObject);
            stopFollowing.Invoke();
        }

        if (other.gameObject.CompareTag("Player"))
        {
            PlayerManager.Instance.PlayerHealth.TakeDamage(Damage);
            Destroy(this.gameObject);
            stopFollowing.Invoke();
        }
    }

    public void DestroyAfterTime()
    {
        if (timer >= secondsUntilDestroy)
        {
            Destroy(gameObject);
            stopFollowing.Invoke();
        }
    }
}