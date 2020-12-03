using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public bool dead = false;
    public GameObject gameover;
    public int Health = 100;

    private void Start()
    {
        gameover.SetActive(false);
        Health = 100;
    }

    private void Update()
    {
        Die();

        if (FindObjectOfType<Revive>().activeOrNot == true)
        {
            gameover.SetActive(false);
        }
    }

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


    public void KillButtom()
    {
        if (Health > 0)
        {
            Health -= 50;
        }
    }
}