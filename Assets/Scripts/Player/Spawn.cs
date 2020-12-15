using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Spawn : MonoBehaviour
{
    public Vector3 FixedSpawn;
    /*public void SaveSpawn()
    {
        PlayerPrefs.SetString("Position", JsonUtility.ToJson(this.transform))
    }*/
    public Death Death;

    public void ReSpawnFixed()
    {
        PlayerManager.Instance.PlayerController.Agent.destination = FixedSpawn;
        this.transform.position = FixedSpawn;
        FindObjectOfType<Death>().gameOverMenu(gameOver: false);
        GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().Health = 100;
        Time.timeScale = 1;
        Death.gameover.SetActive(false);
        Death.dead = false;

        //JsonUtility.FromJson<Vector3>(PlayerPrefs.GetString("Position", " "));
    }

    public void Revive()
    {
        //player.health == 100
        //
    }
}