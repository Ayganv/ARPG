using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.Events;

public class GameOver : MonoBehaviour
{
    public GameObject gameoverMenu;

    public UnityEvent StopAnimation;

    public float DelayTime = 2;
    
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
        yield return new WaitForSeconds(DelayTime);
        gameoverMenu.SetActive(true);
        StopAnimation.Invoke();
    }
}
