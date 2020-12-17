using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    public GameObject helpUI;

    public void OnClickToggle()
    {
        helpUI.gameObject.SetActive(!helpUI.gameObject.activeSelf);
    }
}
