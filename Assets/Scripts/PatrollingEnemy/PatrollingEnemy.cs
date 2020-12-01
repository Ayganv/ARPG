using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : MonoBehaviour {
    public Transform[] waypoints;
    public int speed;
    private int waypointIndex;
    private float distanceToWaypoint;

    // Start is called before the first frame update
    void Start() {
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
    }

    // Update is called once per frame
    void Update() {
        distanceToWaypoint = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if(distanceToWaypoint < 1f) {
            IncreaseIndex();
        }
        Patrol();
    }

    void Patrol() {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void IncreaseIndex() {
        waypointIndex++;
        if(waypointIndex >= waypoints.Length) {
           waypointIndex= 0; 
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }

}
