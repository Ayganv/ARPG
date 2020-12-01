using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerEnemy : MonoBehaviour
{
    public int velocity;
    public ThreatScript threatScript;
    public bool InRange = false;

    private void Update()
    {
        InRange = threatScript.IsPlayerInRange();
    }
    
    void AttackPlayer()
    {
        if (InRange == true)
        {
            //Move towards player transform
            //On collision deal damage every 1-2 seconds?
        }
            
    }



}
