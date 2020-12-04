using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerHealthWithDeath : MonoBehaviour
{
    public int maxHealth;
    public float health;

    public bool dead;
    public GameObject gameover;
    //
    
    //public PlayerController PlayerController;
    private void Start()
    {
        health = maxHealth;
        gameover.SetActive(false);
    }

    private void Update()
    {
        Die();
        if (dead) Time.timeScale = 0;
        else Time.timeScale = 1;
        
        //Temporary commands for testing
        if (Input.GetKeyDown(KeyCode.K)) health = 0;
    }

    public void Die()
    {
        if (health == 0)
        {
            dead = true;
            gameover.SetActive(true);
        }
    }
    
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        print("health: " + health);
    }
}
