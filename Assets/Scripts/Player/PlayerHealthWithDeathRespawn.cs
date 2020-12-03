using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerHealthWithDeathRespawn : MonoBehaviour
{
    public int maxHealth;
    public float health;

    public bool dead;
    public GameObject gameover;

    public Vector3 CurrentSpawn;
    //public PlayerController PlayerController;
    private void Start()
    {
        health = maxHealth;
        gameover.SetActive(false);
        CurrentSpawn = this.transform.position;
    }

    private void Update()
    {
        Die();
        if (dead)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.K)) health = 0;

        if (Input.GetKeyDown(KeyCode.L)) CurrentSpawn = this.transform.position;
    }

    public void Die()
    {
        if (health == 0)
        {
            dead = true;
            gameover.SetActive(true);
        }
    }
    
    public void ReviveButton()
    {
        dead = false;
        health = maxHealth;

        transform.position = CurrentSpawn;
        gameover.SetActive(false);
        GetComponent<NavMeshAgent>().destination = CurrentSpawn;
    }
    
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        print("health: " + health);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn")
        {
            CurrentSpawn = other.transform.position;
            print("new checkpoint set");
        }
    }
}
