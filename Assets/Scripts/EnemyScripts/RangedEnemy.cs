using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [Header("Movement Behaviour Settings")]
    public LayerMask obstacleMask;
    
    [Space]
    public float viewRadius;

    [Header("Combat Settings")]
    public GameObject projectile;

    [Space]
    public float timeBetweenAttack;
    public int damage = 2;

    private bool _playerInRange = false;
    private float _timeSinceLastAttack;

    private Transform _player;
    private PlayerHealth _playerHealth;
    

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _playerHealth = FindObjectOfType<PlayerHealth>();
        _timeSinceLastAttack = timeBetweenAttack;
    }

    private void FixedUpdate()
    {
        if (_playerInRange)
        {

                RangedUnitMovement();
                RangedAttack();
           
        }

        if (PlayerSpotted())
        {
            _playerInRange = true;
        }
        else
        {
            _playerInRange = false;
        }
    }

    private bool PlayerSpotted()
    {
        if (Vector3.Distance(transform.position, _player.position) < viewRadius)
        {
            if (!Physics.Linecast(transform.position, _player.position, obstacleMask))
            {
                return true;
            }
        }

        return false;
    }

   

    private void RangedAttack()
    {
        if (_timeSinceLastAttack <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            _timeSinceLastAttack = timeBetweenAttack;
        }
        else
        {
            _timeSinceLastAttack -= Time.deltaTime;
        }
    }

    private void RangedUnitMovement()
    {
       transform.LookAt(_player);
    }

    //needs reference to player health for attacking
}