using System;
using System.Collections;
using System.Collections.Generic;
using EnemyScripts;
using Player;
using UnityEngine;

public class TargetEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver(){
        if (Input.GetMouseButtonDown(0)){
            PlayerManager.Instance.MeleeAttack.InitiateAttack(this.gameObject);
        }


        if (Input.GetMouseButton(1))
        {
            
            PlayerManager.Instance.RangedAttack.targetPos = transform.position;
            PlayerManager.Instance.RangedAttack.hasATarget = true;
            
        }
        
        else
        {
            PlayerManager.Instance.RangedAttack.hasATarget = false;
        }
    }

    private void OnMouseExit()
    {
        PlayerManager.Instance.RangedAttack.hasATarget = false;
        PlayerManager.Instance.RangedAttack.chargeCounter = PlayerManager.Instance.RangedAttack.chargeUpTime;
    }
}
