using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    
    private Transform player;
    private Vector3 target;

    public bool followingProjectile;

    public float damageToInflict;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        target = new Vector3(player.position.x, player.position.y, player.position.z);
    }
    
    void Update()
    {
        if (followingProjectile == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime); 
        }
        else if (followingProjectile == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime); 
        }
        if (transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z)
            DestroyProjectile();
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
