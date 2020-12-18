using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Portal : MonoBehaviour
{
    [Header("Portal Settings")]
    public int SceneIndex;

    public UnityEvent Teleported;
    public void LoadScene(){
        StartCoroutine(StartPorting()); 
    }
    
    IEnumerator StartPorting()
    {
        Teleported.Invoke();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneIndex);
        
    }
    public void Credits()
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
