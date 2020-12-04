using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {
    public KeyCode moveKey;
    
    public Camera cam;

    NavMeshAgent agent => GetComponent<NavMeshAgent>();

    void Update() {
        if (Input.GetKeyDown(moveKey)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                agent.SetDestination(hit.point);
            }
        }
    }
}
