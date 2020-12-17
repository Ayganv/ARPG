using Player;
using System.Collections;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameoverMenu;

    public float DelayTime = 2;

    private void Start()
    {
        gameoverMenu.SetActive(false);
    }

    public void DelayedGameOverMenu()
    {
        PlayerManager.Instance.PlayerController.enabled = false;
        Time.timeScale = 0;
        StartCoroutine(ShowGameOver());
    }

    private IEnumerator ShowGameOver()
    {
        yield return new WaitForSeconds(DelayTime);
        gameoverMenu.SetActive(true);
    }
}