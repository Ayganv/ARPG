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

        [Header("Charge UI")]
        public Image ChargeBar;

        private void Start()
        {
            HealthUISetup();
            ChargeSetup();
        }

        private void Update()
        {
            UpdateHealthUI(PlayerManager.Instance.PlayerHealth.Health);
            UpdateChargeUI(PlayerManager.Instance.RangedAttack.chargeCounter);
        }

        private void HealthUISetup()
        {
            HealthBar.fillAmount = PlayerManager.Instance.PlayerHealth.Health / 100;
        }

        void ChargeSetup()
        {
            ChargeBar.fillAmount = PlayerManager.Instance.RangedAttack.chargeCounter /
                                   PlayerManager.Instance.RangedAttack.chargeUpTime;
        }

        private void UpdateHealthUI(float HealthAmount)
        {
            HealthBar.fillAmount = HealthAmount / 100;
        }

        void UpdateChargeUI(float ChargeAmount)
        {
            ChargeBar.fillAmount = ChargeAmount / PlayerManager.Instance.RangedAttack.chargeUpTime;
        }
    }
}