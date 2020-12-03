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
        Health = 100;
        Revive = FindObjectOfType<Revive>();
        Player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (Revive.activeOrNot)
        {
            gameover.SetActive(false);
        }

        if (Health == 0)
        {
            Die(false, Vector3.zero, Vector3.zero, true);
        }
    }

    /*
    public void Die()
    {
        if (Health == 0)
        {
            dead = true;
            GameObject.FindWithTag("Player").GetComponent<playerMovement>().enabled = false;
            GameObject.FindWithTag("Player").GetComponent<Rigidbody>().velocity = Vector3.zero;
            GameObject.FindWithTag("Player").GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            gameover.SetActive(true);
        }
    }
 */
    public void Die(bool playerMovement, Vector3 velocity, Vector3 angularVelocity, bool gameOver)
    {
        dead = true;
        Player.GetComponent<playerMovement>().enabled = playerMovement;
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