//using System.Collections;

using Player;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class MaxRespawn : MonoBehaviour
{
    public Vector3 CurrentSpawn;

    public GameObject DeathEffect;
    public VisualEffect ReviveEffect;

    private PlayerHealth playerHealth;
    private GameOver gameOver;

    private void Start()
    {
        ReviveEffect.Stop();
        CurrentSpawn = this.transform.position;
        playerHealth = GetComponent<PlayerHealth>();
        gameOver = FindObjectOfType<GameOver>();
    }

    private void Update()
    {
        //Temporary commands for testing
        if (Input.GetKeyDown(KeyCode.L)) CurrentSpawn = this.transform.position;

        if (playerHealth.Dead == false)
        {
            DeathEffect.SetActive(false);
        }
    }

    public void ReviveAtCheckPointButton()
    {
        ReviveEffect.Play();
        playerHealth.Dead = false;
        playerHealth.Health = playerHealth.MaxHealth;
        GetComponent<NavMeshAgent>().ResetPath();
        GetComponent<NavMeshAgent>().enabled = false;

        gameOver.gameoverMenu.SetActive(false);
        PlayerManager.Instance.transform.position = CurrentSpawn;

        GetComponent<NavMeshAgent>().enabled = true;
        PlayerManager.Instance.PlayerController.enabled = true;
        Time.timeScale = 1;
    }

    public void ReviveAtCorpseButton()
    {
        ReviveEffect.Play();
        playerHealth.Dead = false;
        playerHealth.Health = playerHealth.MaxHealth;
        gameOver.gameoverMenu.SetActive(false);
        GetComponent<NavMeshAgent>().destination = transform.position;
        PlayerManager.Instance.PlayerController.enabled = true;
        Time.timeScale = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn")
        {
            CurrentSpawn = other.transform.position;
            print("new checkpoint set at position: " + CurrentSpawn);
        }
    }
}