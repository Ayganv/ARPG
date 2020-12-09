using Player;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth;
    public float Health;

    [Space]
    public bool Dead;

    public UnityEvent OnDeath;
    public UnityEvent OnTakingDamage;
    
    public float redColorDuration;

    private Color regularColor;
    private Renderer Renderer => GetComponent<Renderer>();
    private float timer;

    private void Start()
    {
        Health = MaxHealth;

        regularColor = Renderer.material.color;
    }

    private void Update()
    {
        UpdateTimer();

        ResetColor();

        //Temporary commands for testing
        if (Input.GetKeyDown(KeyCode.K)) Health = 0;

        if (Health <= 0)
        {
            Die();
        }
    }

    private void UpdateTimer()
    {
        timer += Time.deltaTime;
    }

    public void Die()
    {
        Dead = true;
        OnDeath.Invoke();

        ResetColor();

        Debug.Log($"{this} has died");
    }

    public void TakeDamage(float damageAmount)
    {
        Health -= damageAmount;
        Renderer.material.color = Color.red;
        timer = 0;
        print($"{this} has taken {damageAmount} damage, {PlayerManager.Instance.PlayerHealth.Health} health remain");
        OnTakingDamage.Invoke();
    }

    public void ResetColor()
    {
        if (timer >= redColorDuration)
        {
            Renderer.material.color = regularColor;
        }
    }
}