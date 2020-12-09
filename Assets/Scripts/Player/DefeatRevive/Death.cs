using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public bool dead = false;
    public GameObject gameover;
    public int Health = 100;
    private Revive Revive;
    private GameObject Player;

    private void Start()
    {
        gameover.SetActive(false);
        Revive = FindObjectOfType<Revive>();
        Player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (Health == 0)
        {
            Die(true, false, Vector3.zero, Vector3.zero, true);
        }
    }

    public void Die(bool dead, bool playerMovement, Vector3 velocity, Vector3 angularVelocity, bool gameOver)
    {
        dead = dead;
        // Player.GetComponent<playerMovement>().enabled = playerMovement;
        Player.GetComponent<Rigidbody>().velocity = velocity;
        Player.GetComponent<Rigidbody>().angularVelocity = angularVelocity;
        gameover.SetActive(gameOver);
    }


    public void KillButtom()
    {
        if (Health > 0)
        {
            Health -= 50;
        }
    }
}