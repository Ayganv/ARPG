using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public bool dead1 = false;
    public GameObject gameover;
    private PlayerHealth Health;
    private Revive Revive;
    private GameObject Player;

    private void Start()
    {
        gameover.SetActive(false);
        Revive = FindObjectOfType<Revive>();
        Player = GameObject.FindWithTag("Player");
        Health = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        if (Health.Health == 0)
        {
            var vectorzero = new Vector3(0,0,0);
            Die(true, false, vectorzero, vectorzero, true);
        }
    }

    public void Die(bool deadbool, bool playerMovement, Vector3 velocity, Vector3 angularVelocity, bool gameOver)
    {
        dead1 = deadbool;
        Player.GetComponent<PlayerController>().enabled = playerMovement;
        Player.GetComponent<Rigidbody>().velocity = velocity;
        Player.GetComponent<Rigidbody>().angularVelocity = angularVelocity;
        gameover.SetActive(gameOver);
    }


    public void KillButtom()
    {
        if (Health.Health > 0)
        {
            Health.Health -= 50;
        }
    }
}