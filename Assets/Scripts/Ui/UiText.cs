using UnityEngine;
using UnityEngine.UI;

public class UiText : MonoBehaviour
{
    public Text HealthText;

    private PlayerHealth PlayerHealth;

    private void Awake()
    {
        PlayerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        HealthText.text = $"Health: {PlayerHealth.Health}";
    }
}