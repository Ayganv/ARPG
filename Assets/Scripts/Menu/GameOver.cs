using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.Events;

public class GameOver : MonoBehaviour
{
    public GameObject gameoverMenu;

    public UnityEvent StopAnimation;
    
    void Start()
    {
        gameoverMenu.SetActive(false);
    }
    

    public void DelayedGameOverMenu()
    {
        PlayerManager.Instance.PlayerController.enabled = false;
        Time.timeScale = 0;
        StartCoroutine(ShowGameOver());
    }
    
    
    
    
    IEnumerator ShowGameOver()
    {
        yield return new WaitForSeconds(2);
        gameoverMenu.SetActive(true);
        StopAnimation.Invoke();
    }
}
