using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text healthTxt;
    public Death Death;

    void Update()
    {
        this.healthTxt.text = $@"Health: {(GetComponent<PlayerHealth>().Health)}";
        this.healthTxt.color = Color.red;
    }
}