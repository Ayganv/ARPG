using UnityEngine;
using UnityEngine.UI;

public class FadeAwayImage : MonoBehaviour
{
    private Image levelSign => GetComponent<Image>();

    private float timer;
    public float timeUntilFade = 5;
    public float fadeDuration = 0.5f;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeUntilFade)
        {
            FadeOut();
        }
    }

    public void FadeOut()
    {
        levelSign.CrossFadeAlpha(0f, fadeDuration, false);
    }
}