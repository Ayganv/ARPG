using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public bool dead;
    public int Health = 100;
    public GameObject gameover;

    private void Start()
    {
        gameover.SetActive(false);
    }

    private void Update()
    {
        Die();
    }

    public void Die()
    {
        if (Health == 0)
        {
            dead = true;
            GameObject.FindWithTag("Player").SetActive(false);
            gameover.SetActive(true);
        }
        else
        {
            return;
        }
    }


    public void ReviveButtom()
    {
        GameObject.FindWithTag("Player").SetActive(true);
        gameover.SetActive(false);
    }


    public void KillButtom()
    {
        Health -= 100;
    }
}