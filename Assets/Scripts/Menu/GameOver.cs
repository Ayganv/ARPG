using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameoverMenu;

    private PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        gameoverMenu.SetActive(false);
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.dead)
        {
            gameoverMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else Time.timeScale = 1;
    }
}
