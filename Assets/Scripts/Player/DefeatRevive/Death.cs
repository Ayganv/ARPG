using Player;
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
    public Vector3 DeathPosition;

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
           
            Die(true, false, true);
            Time.timeScale = 0;
        }
    }

    public void Die(bool deadbool, bool playerMovement, bool gameOver)
    {
        DeathPosition = this.transform.position;
        dead1 = deadbool;
        Player.GetComponent<PlayerController>().enabled = playerMovement;
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