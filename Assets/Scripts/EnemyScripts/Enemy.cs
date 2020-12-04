using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   public GameObject projectile;
    public LayerMask obstacleMask;
    [Space]
    public float MovementSpeed;
    [Space]
    public float StoppingDistance;
    public float RetreatDistance;
    public float ViewRadius;
    [Space]
    public float TimeBetweenAttack;
    public int MeleeDamage = 2;
    public bool EnemyIsRanged = false;

    private bool playerInRange = false;
    private float timeSinceLastAttack;
    private Transform player;
    private PlayerHealth playerHealth;
    


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = FindObjectOfType<PlayerHealth>(); 
        timeSinceLastAttack = TimeBetweenAttack;
        
    }

    
    void FixedUpdate()
    {
        if (playerInRange)
        {
            if (EnemyIsRanged)
            {
                RangedUnitMovement();
                RangedAttack();
            }
            else
            {
                MeleeUnitMovement();
                MeleeAttack();
            }
        }

        if (PlayerSpotted())
        {
            playerInRange = true;
        }
        else playerInRange = false;
    }
    
    bool PlayerSpotted()
    {
        if (Vector3.Distance(transform.position, player.position) < ViewRadius)
        {
            if (!Physics.Linecast(transform.position, player.position, obstacleMask))
            {
                return true;
            }
        }
        return false;
    }

    private void RangedUnitMovement()
    {
        if (Vector3.Distance(transform.position, player.position) > StoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, MovementSpeed * Time.deltaTime);
            
        } else if (Vector3.Distance(transform.position, player.position) < StoppingDistance && Vector3.Distance(transform.position, player.position) > RetreatDistance)
        {
            transform.position = this.transform.position;
            
        } else if (Vector3.Distance(transform.position, player.position) < RetreatDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, -MovementSpeed * Time.deltaTime);
        }
    }

    private void MeleeUnitMovement()
    {
        if (Vector3.Distance(transform.position, player.position) >= StoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, MovementSpeed * Time.deltaTime);
        }
    }


    private void MeleeAttack()
    {
        if (Vector3.Distance(transform.position, player.position) <= StoppingDistance)
        {
            if (timeSinceLastAttack <= 0)
            {
                playerHealth.TakeDamage(MeleeDamage);
                timeSinceLastAttack = TimeBetweenAttack;
            }
            else
            {
                timeSinceLastAttack -= Time.deltaTime;
            }
        }
    }

    private void RangedAttack()
    {
        if (timeSinceLastAttack <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeSinceLastAttack = TimeBetweenAttack;
        }
        else
        {
            timeSinceLastAttack -= Time.deltaTime;
        }
    }

    //needs reference to player health for attacking

}
