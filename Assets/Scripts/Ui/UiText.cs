using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiText : MonoBehaviour
{
    public Text healthText;

    private void Update()
    {
        healthText.text = "Health: " + FindObjectOfType<PlayerHealth>().health;
    }
}
