using UnityEngine;
using UnityEngine.Events;

namespace Units{
    public class UnitHealth:MonoBehaviour{
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

        public virtual void Update()
        {
            if (Health <= 0 && !Dead)
            {
                OnDeath.Invoke();
                Die();
            } 
        }

        private void Die()
        {
            Dead = true;
            Debug.Log($"{this} has died");
        }
        
        public virtual void TakeDamage(int damageAmount)
        {
            Health -= damageAmount;
            print($"{this} has taken {damageAmount} damage, {Health} health remain");
            OnTakingDamage.Invoke();
        }
    }
}