using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revive : MonoBehaviour
{
    public void ReviveButtom()
    {
        FindObjectOfType<Death>().Die(deadbool: false, playerMovement: true,
            gameOver: false);
        GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().Health = 100;
        Time.timeScale = 1;
    }
}