using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Portal : MonoBehaviour
{
    [Header("Portal Settings")]
    public int SceneIndex;

    public void LoadScene(){

        SceneManager.LoadScene(SceneIndex);
    }
}
