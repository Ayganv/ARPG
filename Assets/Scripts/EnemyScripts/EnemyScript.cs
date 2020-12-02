using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{   public GameObject projectile;
    public LayerMask obstacleMask;
    
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float startTimeBetweenShots;
    public float viewRadius;
    public bool EnemyIsRanged = false;
    
    private bool PlayerInRange = false;
    private float timeBetweenShots;
    private Transform player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBetweenShots = startTimeBetweenShots;
        
    }

    
    void FixedUpdate()
    {
        
        if (EnemyIsRanged)
        {
            RangedUnit();
        }
        else MeleeUnit();
        
        if (PlayerSpotted())
        {
            PlayerInRange = true;
        }
       
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
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }

    private void MeleeUnit()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        //needs reference to player health for attacking
    }
}
