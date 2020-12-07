using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public float health;
    public bool dead;
    
    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        Die();
        
        //Temporary commands for testing
        if (Input.GetKeyDown(KeyCode.K)) health = 0;
    }

    public void Die()
    {
        if (health == 0) dead = true;
    }
    
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        print("health lost");
    }
}
