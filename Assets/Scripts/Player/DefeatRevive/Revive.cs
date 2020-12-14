using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Revive : MonoBehaviour
{
    public void ReviveButtom()
    {
        FindObjectOfType<Death>().Die(deadbool: false, playerMovement: true,
            gameOver: false);
        GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().Health = 100;
        PlayerManager.Instance.PlayerController.Agent.destination = FindObjectOfType<Death>().DeathPosition;
        Time.timeScale = 1;
    }
}