using UnityEngine;

public class DamageIndicator : MonoBehaviour
{
    [Header("Damage Indication Settings")]
    public float DamageIndicatorDuration;

    [Space]
    public Color DamageIndicatorColor;

    private bool TimerActive = false;

    private Color OriginalColor;
    private Renderer[] Renderers;
    private float TimeElasped;

    private void Awake()
    {
        Renderers = GetComponentsInChildren<Renderer>();
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
        foreach (Renderer renderer in Renderers)
        {
            renderer.material.color = DamageIndicatorColor;
        }
        TimerActive = true;
    }

    private void ResetColor()
    {
        if (TimeElasped >= DamageIndicatorDuration)
        {
            foreach (Renderer renderer in Renderers)
            {
                renderer.material.color = Color.white;
            }
            TimeElasped = 0.0f;
            TimerActive = false;
        }
    }

    private void UpdateTimer()
    {
        TimeElasped += Time.deltaTime;
    }
}