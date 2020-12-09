using UnityEngine;

public class PatrollingEnemy : MonoBehaviour
{
    public Transform[] waypoints;
    public int Speed;
    public float AttackDamage = 1;
    private int waypointIndex;
    private float distanceToWaypoint;
    private PlayerHealth playerHealth;

    private void Start()
    {
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void FixedUpdate()
    {
        distanceToWaypoint = Vector3.Distance(transform.position, waypoints[waypointIndex].position);

        if (distanceToWaypoint < 1f)
        {
            IncreaseIndex();
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