using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public bool dead;
    public GameObject gameover;
    private PlayerHealth Health;
    private Revive Revive;
    private GameObject Player;
    public Vector3 deathPosition;
    private bool isDying;

    private void Start()
    {
        gameOverMenu(false);
        Revive = FindObjectOfType<Revive>();
        Player = GameObject.FindWithTag("Player");
        Health = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        if (Health.Health <= 0 && !dead)
        {
            dead = true;
            Player.GetComponent<PlayerController>().enabled = false;
            StartCoroutine(DelayGameOver(5));
            gameOverMenu(true);
        }
        
    }
    IEnumerator DelayGameOver(float delayTime)
    {
        Debug.Log("Player has died");
        yield return new WaitForSeconds(delayTime);
        Debug.Log("Showing Menu");
    }


    public void gameOverMenu(bool gameOver)
    {
        deathPosition = this.transform.position;
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