using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    
    private Transform player;
    private Vector3 target;

    public float damageToInflict;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        target = new Vector3(player.position.x, player.position.y, player.position.z);
    }
    
    void Update()
    {
        ProjectileTarget(target);

        /*if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }*/
    }

    void ProjectileTarget(Vector3 activeTarget)
    {
        transform.position = Vector3.MoveTowards(transform.position, activeTarget, speed * Time.deltaTime); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            DestroyProjectile();
        }
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<PlayerHealth>().TakeDamage(damageToInflict);
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
    
}
