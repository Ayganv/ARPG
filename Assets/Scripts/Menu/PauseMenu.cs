using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("Menu Settings")]
    public KeyCode MenuKey;

    [Space]
    public GameObject MenuObject;

    private void Update(){
        
        if(Input.GetKeyDown(MenuKey)){

            ToggleMenu(true);
        }
    }

    public void ToggleMenu(bool toggleBool){

        MenuObject.SetActive(toggleBool);
    }

    public void ExitButton(){

        Debug.Log("Exit Game");
        Application.Quit();
    }
}
