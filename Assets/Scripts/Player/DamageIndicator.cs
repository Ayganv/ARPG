using UnityEngine;

public class DamageIndicator : MonoBehaviour
{
    [Header("Damage Indication Settings")]
    public float DamageIndicatorDuration;

    [Space]
    public Color DamageIndicatorColor;

    private bool TimerActive = false;

    private Color OriginalColor;
    private Renderer Renderer => GetComponent<Renderer>();
    private float TimeElasped;

    private void Awake()
    {
        OriginalColor = Renderer.material.color;
    }

    private void Update()
    {
        ResetColor();

        if (TimerActive)
        {
            UpdateTimer();
        }
    }

    public void StartDamageIndicator()
    {
        Renderer.material.color = DamageIndicatorColor;
        TimerActive = true;
    }

    private void ResetColor()
    {
        if (TimeElasped >= DamageIndicatorDuration)
        {
            Renderer.material.color = OriginalColor;
            TimeElasped = 0.0f;
            TimerActive = false;
        }
    }

    private void UpdateTimer()
    {
        TimeElasped += Time.deltaTime;
    }
}