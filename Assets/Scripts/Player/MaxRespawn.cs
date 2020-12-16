//using System.Collections;

using System;
using System.Collections.Generic;
using Player;
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

    public void ReviveAtCheckPointButton()
    {
        playerHealth.Dead = false;
        playerHealth.Health = playerHealth.MaxHealth;
        
        GetComponent<NavMeshAgent>().ResetPath();
        GetComponent<NavMeshAgent>().enabled = false;

        gameOver.gameoverMenu.SetActive(false);
        PlayerManager.Instance.transform.position = CurrentSpawn;
        
        GetComponent<NavMeshAgent>().enabled = true;
    }

    public void ReviveAtCorpseButton()
    {
        playerHealth.Dead = false;
        playerHealth.Health = playerHealth.MaxHealth;

        gameOver.gameoverMenu.SetActive(false);
        GetComponent<NavMeshAgent>().destination = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn")
        {
            CurrentSpawn = other.transform.position;
            print("new checkpoint set at position: " + CurrentSpawn);
        }
    }
}