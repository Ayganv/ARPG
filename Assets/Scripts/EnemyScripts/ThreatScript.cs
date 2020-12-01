using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
public class ThreatScript : MonoBehaviour
{

    public float viewRadius;
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    

    private void Start()
    {
        StartCoroutine ("FindTargetsWithDelay", .2f);
    }


    IEnumerator FindTargetsWithDelay(float delay) {
        while (true) {
            yield return new WaitForSeconds (delay);
           FindVisibleTargets ();
        }
    }

    void FindVisibleTargets() {
        
        Collider[] targetsInViewRadius = Physics.OverlapSphere (transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++) {
            Transform target = targetsInViewRadius [i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            float dstToTarget = Vector3.Distance (transform.position, target.position);

                if (!Physics.Raycast (transform.position, dirToTarget, dstToTarget, obstacleMask))
                {

                    IsPlayerInRange();
                }
        }
    }

    public bool IsPlayerInRange()
    {
        return true;
    }
}
