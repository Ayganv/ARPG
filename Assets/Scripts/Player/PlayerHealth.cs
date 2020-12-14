using Player;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth;
    public int Health;

    [Space]
    public bool Dead;

    [Header("Unity Events")]
    public UnityEvent OnDeath;

    public UnityEvent OnTakingDamage;

    public DamageIndicator DamageIndicator => GetComponent<DamageIndicator>();

    private void Start()
    {
        Health = MaxHealth;
    }

    private void Update()
    {
        //Temporary commands for testing
        if (Input.GetKeyDown(KeyCode.K)) Health = 0;

        if (Health <= 0 && !Dead)
        {
            OnDeath.Invoke();
            Die();
        } 
    }

    public void Die()
    {
        Dead = true;
        Debug.Log($"{this} has died");
    }

    public void TakeDamage(int damageAmount)
    {
        Health -= damageAmount;
        print($"{this} has taken {damageAmount} damage, {PlayerManager.Instance.PlayerHealth.Health} health remain");
        OnTakingDamage.Invoke();
    }
}