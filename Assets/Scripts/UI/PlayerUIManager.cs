using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player.UI
{
    public class PlayerUIManager : MonoBehaviour
    {
        [Header("Health UI")]
        public Image HealthBar;

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
            HealthBar.fillAmount = PlayerManager.Instance.PlayerHealth.Health / 100;
        }

        private void UpdateHealthUI(float HealthAmount)
        {
            HealthBar.fillAmount = HealthAmount / 100;
        }
    }
}