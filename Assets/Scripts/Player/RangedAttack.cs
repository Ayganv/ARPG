using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public GameObject projectile;
    public float chargeUpTime;
    private float _chargeCounter;
    public Vector3 targetPos;
    public bool hasATarget;
    
    
    void Start()
    {
        _chargeCounter = chargeUpTime;
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
            _chargeCounter = chargeUpTime;
        }
    }

    private void ChargeAttack()
    {
        if (_chargeCounter <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            _chargeCounter = chargeUpTime;
        }
        else
        {
            _chargeCounter -= Time.deltaTime;
        }
    }
    
}
