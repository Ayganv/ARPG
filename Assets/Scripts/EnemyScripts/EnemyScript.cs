using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{   public GameObject projectile;
    public LayerMask obstacleMask;
    //public PlayerHealth playerHealth;
    
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float startTimeBetweenAttack;
    public float viewRadius;
    public int meeleDamage = 2;
    public bool EnemyIsRanged = false;
    
    
    private bool PlayerInRange = false;
    private float timeBetweenShots;
    private Transform player;
    


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        timeBetweenShots = startTimeBetweenAttack;
        
    }

    
    void FixedUpdate()
    {
        if (PlayerInRange)
        {
            if (EnemyIsRanged)
            {
                RangedUnit();
            }
            else MeleeUnit();
        }

        if (PlayerSpotted())
        {
            PlayerInRange = true;
        }
        else PlayerInRange = false;

    }
    
    bool PlayerSpotted()
    {
        if (Vector3.Distance(transform.position, player.position) < viewRadius)
        {
            if (!Physics.Linecast(transform.position, player.position, obstacleMask))
            {
                return true;
            }
        }

        return false;
    }

    private void RangedUnit()
    {
        if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            
        } else if (Vector3.Distance(transform.position, player.position) < stoppingDistance && Vector3.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
            
        } else if (Vector3.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timeBetweenShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenAttack;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }

    private void MeleeUnit()
    {
        if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        else
        {
            if (timeBetweenShots <= 0)
            {
                FindObjectOfType<PlayerHealth>().TakeDamage(meeleDamage);
                timeBetweenShots = startTimeBetweenAttack;
            }
            else
            {
                timeBetweenShots -= Time.deltaTime;
            }
        }

        //needs reference to player health for attacking
    }
}
