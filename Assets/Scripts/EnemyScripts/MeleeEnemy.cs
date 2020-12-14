using UnityEngine;
using UnityEngine.Events;

public class MeleeEnemy : MonoBehaviour
{
    [Header("Movement Behaviour Settings")]
    public LayerMask obstacleMask;

    [Space]
    public float movementSpeed;

    [Space]
    public float stoppingDistance;

    public float viewRadius;

    [Header("Combat Settings")]
    public float timeBetweenAttack;

    public int damage = 2;

    private bool _playerInAggroRange = false;
    private float _timeSinceLastAttack;

    private Transform _player;
    private PlayerHealth _playerHealth;
    
    public UnityEvent OnAttacking;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _playerHealth = _player.GetComponent<PlayerHealth>();
        _timeSinceLastAttack = timeBetweenAttack;
    }

    private void FixedUpdate()
    {
        if (_playerInAggroRange)
        {
            MeleeUnitMovement();
            MeleeAttack();
        }

        if (PlayerSpotted())
        {
            _playerInAggroRange = true;
        }
        else
        {
            _playerInAggroRange = false;
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

    private void MeleeUnitMovement()
    {
        if (Vector3.Distance(transform.position, _player.position) >= stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.position, movementSpeed * Time.deltaTime);
        }
    }

    private void MeleeAttack()
    {
        if (Vector3.Distance(transform.position, _player.position) <= stoppingDistance)
        {
            if (_timeSinceLastAttack <= 0)
            {
                _playerHealth.TakeDamage(damage);
                OnAttacking.Invoke();
                _timeSinceLastAttack = timeBetweenAttack;
            }
            else
            {
                _timeSinceLastAttack -= Time.deltaTime;
            }
        }
    }

    //needs reference to player health for attacking
}