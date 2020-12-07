using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement Behaviour Settings")]
    public LayerMask obstacleMask;

    [Space]
    public float MovementSpeed;

    [Space]
    public float StoppingDistance;

    public float RetreatDistance;
    public float ViewRadius;

    [Header("Combat Settings")]
    public bool IsRanged = false;

    public GameObject projectile;

    [Space]
    public float TimeBetweenAttack;

    public int Damage = 2;

    private bool playerInRange = false;
    private float timeSinceLastAttack;

    private Transform player;
    private PlayerHealth playerHealth;
    public bool Stationary;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = FindObjectOfType<PlayerHealth>();
        timeSinceLastAttack = TimeBetweenAttack;
    }

    private void FixedUpdate()
    {
        if (playerInRange)
        {
            if (IsRanged)
            {
                RangedUnitMovement();
                RangedAttack();
            }
            else
            {
                if(Stationary)
                {
                    StationaryAttack();
                }
                else
                {
                    MeleeUnitMovement();
                    MeleeAttack();
                }
                
            }
        }

        if (PlayerSpotted())
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }
    }

    private bool PlayerSpotted()
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
                playerHealth.TakeDamage(Damage);
                timeSinceLastAttack = TimeBetweenAttack;
            }
            else
            {
                timeSinceLastAttack -= Time.deltaTime;
            }
        }
    }

    private void StationaryAttack()
    {
        if (timeSinceLastAttack <= 0)
            {
                playerHealth.TakeDamage(Damage);
                timeSinceLastAttack = TimeBetweenAttack;
            }
            else
            {
                timeSinceLastAttack -= Time.deltaTime;
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

    private void RangedUnitMovement()
    {
        if (Vector3.Distance(transform.position, player.position) > StoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, MovementSpeed * Time.deltaTime);
        }
        else if (Vector3.Distance(transform.position, player.position) < StoppingDistance && Vector3.Distance(transform.position, player.position) > RetreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector3.Distance(transform.position, player.position) < RetreatDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, -MovementSpeed * Time.deltaTime);
        }
    }

    //needs reference to player health for attacking
}