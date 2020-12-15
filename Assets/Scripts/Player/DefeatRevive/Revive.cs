using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Revive : MonoBehaviour
{
    private Death Death;
    public void ReviveButtom()
    {
        FindObjectOfType<Death>().dead = false;
        FindObjectOfType<Death>().gameOverMenu(gameOver: false);
        FindObjectOfType<PlayerController>().enabled = true;
        GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().Health = 100;
        PlayerManager.Instance.PlayerController.Agent.destination = FindObjectOfType<Death>().deathPosition;
    }
}