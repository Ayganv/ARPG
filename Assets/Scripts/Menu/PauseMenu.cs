using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    
    //used to trigger main music theme and pause music
    public UnityEvent startPlaying;
    public UnityEvent pausePlaying;

    [Header("Menu Settings")]
    public KeyCode MenuKey;

    [Space]
    public GameObject MenuObject;

    [Space]
    public bool IsPaused;

    private void Awake() {

        if(instance != null && instance != this){

            Destroy(this.gameObject);
        }else{

            instance = this;
        }

        if (startPlaying == null){
            startPlaying = new UnityEvent();
        }
        
        if (pausePlaying == null){
            pausePlaying = new UnityEvent();
        }
    }

    private void Start(){
        startPlaying.Invoke();
    }

    private void Update(){
        
        if(IsPaused){

            Time.timeScale = 0;
        }else{

            Time.timeScale = 1;
        }

        if(Input.GetKeyDown(MenuKey)){

            ToggleMenu(true);
        }
    }

    public void ToggleMenu(bool toggleBool){

        if(toggleBool == true){

            IsPaused = true;
            pausePlaying.Invoke();
        }else{

            IsPaused = false;
            startPlaying.Invoke();
        }

        MenuObject.SetActive(toggleBool);
    }

    public void LoadScene(int Index){

        ToggleMenu(false);
        SceneManager.LoadScene(Index);
    }

    public void QuitGame(){

        Application.Quit();
    }
}
