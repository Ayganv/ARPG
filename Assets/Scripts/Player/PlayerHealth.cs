using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public float health;
    public bool dead;

    private Color regularColor;
    private Renderer renderer;
    private float timer;
    public float redColorDuration;
    private void Start()
    {
        health = maxHealth;
        
        renderer = GetComponent<Renderer>();
        regularColor = renderer.material.color;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        
        Die();
        ResetColor();
        
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
        renderer.material.color = Color.red;
        timer = 0;
        print(health + "health remaining");
        
    }

    public void ResetColor()
    {
        if (timer >= redColorDuration)
        {
            renderer.material.color = regularColor;
        }
    }
}
