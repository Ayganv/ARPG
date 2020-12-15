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
            Debug.Log(this.gameObject + "plant targeted with mouse left mouse button");
            PlayerManager.Instance.GetComponent<MeleeAttack>().InitiateAttack(this.gameObject);
        }
            
        
        if(Input.GetMouseButtonDown(1))
            Debug.Log(this.gameObject + "plant targeted with mouse right mouse button");
    }
}
