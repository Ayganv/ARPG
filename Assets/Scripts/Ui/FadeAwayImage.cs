using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAwayImage : MonoBehaviour
{
    private Image levelSign => GetComponent<Image>();

    private float timer;
    public float timeUntilFade = 5;
    

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
        levelSign.CrossFadeAlpha(0f, 2f,false);
    }
}
