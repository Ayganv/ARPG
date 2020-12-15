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
        ChargeAttack();
    }

    private void ChargeAttack()
    {
        if (Input.GetMouseButton(1))
        {
            if (hasATarget)
            {
                chargeCounter -= Time.deltaTime;
            }
        }
        else if (chargeCounter <= 0 && Input.GetMouseButtonUp(1))
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
        }
        else
        {
            chargeCounter = chargeUpTime;
        }
    }


    
}
