using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player.UI
{
    public class PlayerUIManager : MonoBehaviour
    {
        [Header("Health UI")]
        public Text HealthText;

        [Space]
        public Slider HealthBar;

        private void Start()
        {
            HealthUISetup();
        }

        private void Update()
        {
            UpdateHealthUI(PlayerManager.Instance.PlayerHealth.Health);
        }

        private void HealthUISetup()
        {
            HealthBar.maxValue = PlayerManager.Instance.PlayerHealth.MaxHealth;
            HealthBar.value = PlayerManager.Instance.PlayerHealth.Health;
        }

        private void UpdateHealthUI(float HealthAmount)
        {
            HealthBar.value = HealthAmount;
            HealthText.text = "" + HealthAmount;
        }
    }
}