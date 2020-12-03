using System.Collections;
using System.Collections.Generic;
using System.Net.Configuration;
using UnityEngine;

public class Revive : MonoBehaviour
{
    public GameObject gameover;
    public bool activeOrNot = false;

    public void ReviveButtom()
    {
        GameObject.FindWithTag("Player").GetComponent<playerMovement>().enabled = true;
        GameObject.FindWithTag("Player").GetComponent<Rigidbody>().velocity = Vector3.one;
        GameObject.FindWithTag("Player").GetComponent<Rigidbody>().angularVelocity = Vector3.one;
        GameObject.FindWithTag("Player").GetComponent<Death>().Health += 100;
        activeOrNot = true;
    }
}