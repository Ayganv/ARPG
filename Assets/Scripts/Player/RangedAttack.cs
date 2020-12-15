using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public GameObject projectile;
    public float chargeUpTime;
    public float chargeCounter;
    public Vector3 targetPos;
    public bool hasATarget;
    
    
    void Start()
    {
        chargeCounter = chargeUpTime;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (hasATarget)
            {
                ChargeAttack();
            }
        }
        else
        {
            chargeCounter = chargeUpTime;
        }
    }

    private void ChargeAttack()
    {
        if (chargeCounter <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            chargeCounter = chargeUpTime;
        }
        else
        {
            chargeCounter -= Time.deltaTime;
        }
    }
    
}
