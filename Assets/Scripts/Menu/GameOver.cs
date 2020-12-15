using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameoverMenu;

    
    void Start()
    {
        gameoverMenu.SetActive(false);
    }
    
    void Update()
    {
        if (PlayerManager.Instance.PlayerHealth.Dead)
        {
            PlayerManager.Instance.PlayerController.enabled = false;
            gameoverMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            PlayerManager.Instance.PlayerController.enabled = true;
            Time.timeScale = 1;
        }
    }
}
