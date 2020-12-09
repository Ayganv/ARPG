//using System.Collections;

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MaxRespawn : MonoBehaviour
{
    public Vector3 CurrentSpawn;


    private PlayerHealth playerHealth;
    private GameOver gameOver;
    private void Start()
    {
        CurrentSpawn = this.transform.position;
        playerHealth = GetComponent<PlayerHealth>();
        gameOver = FindObjectOfType<GameOver>();
    }

    private void Update()
    {
        //Temporary commands for testing
        if (Input.GetKeyDown(KeyCode.L)) CurrentSpawn = this.transform.position;
    }
    
    public void ReviveButton()
    {
        playerHealth.Dead = false;
        playerHealth.Health = playerHealth.MaxHealth;

        transform.position = CurrentSpawn;
        gameOver.gameoverMenu.SetActive(false);
        GetComponent<NavMeshAgent>().destination = CurrentSpawn;
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
