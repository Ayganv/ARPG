using UnityEngine;
using UnityEngine.Events;

public class PatrollingEnemy : MonoBehaviour
{
    public Transform[] waypoints;
    public int Speed;
    public float AttackDamage = 1;

    private int waypointIndex;
    private float distanceToWaypoint;
    private PlayerHealth playerHealth;
    [Space]
    public float absorbDistance = 2f;
    public float shootDistance = 1;
    [Space]
    public UnityEvent OnShooting;
    public UnityEvent OnAbsorbing;

   
    
    private bool hasAbsorbed = false;
    
    private void Start()
    {
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void FixedUpdate()
    {
        distanceToWaypoint = Vector3.Distance(transform.position, waypoints[waypointIndex].position);

        if (distanceToWaypoint < absorbDistance && !hasAbsorbed){
            OnAbsorbing.Invoke();
            hasAbsorbed = true;
        }
        
        if (distanceToWaypoint < shootDistance)
        {
            OnShooting.Invoke();
            IncreaseIndex();
            hasAbsorbed = false;
        }

        Patrol();
    }

    private void Patrol()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    private void IncreaseIndex()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }

    private void Attack()
    {
        playerHealth.TakeDamage(AttackDamage);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("touched player");
            Attack();

            //either destroy acorn or reset it to one of the waypoints
        }
    }
}