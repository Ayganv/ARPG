using UnityEngine;
using UnityEngine.UI;

public class FadeAwayText : MonoBehaviour
{
    private Text text => GetComponent<Text>();

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
        text.CrossFadeAlpha(0f, fadeDuration, false);
    }
}