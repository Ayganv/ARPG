using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : MonoBehaviour {
    public Transform[] waypoints;
    public int Speed;
    public float AttackDamage = 1;
    private int waypointIndex;
    private float distanceToWaypoint;
    private Transform player;
    private PlayerHealth playerHealth;

    void Start() {
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void FixedUpdate() {
        distanceToWaypoint = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if(distanceToWaypoint < 1f) {
            IncreaseIndex();
        }
        //if (Vector3.Distance())
        Patrol();
    }

    void Patrol() 
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    void IncreaseIndex() {
        waypointIndex++;
        if(waypointIndex >= waypoints.Length) {
           waypointIndex= 0; 
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }

    void Attack()
    {
        playerHealth.TakeDamage(AttackDamage);
    }

}
