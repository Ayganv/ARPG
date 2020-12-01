using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadScene(int SceneIndex){

        Debug.Log("Loading Scene " + SceneIndex);
        SceneManager.LoadScene(SceneIndex);
    }

    public void QuitGame(){

        Debug.Log("Exit Game!");
        Application.Quit();
    }
}
