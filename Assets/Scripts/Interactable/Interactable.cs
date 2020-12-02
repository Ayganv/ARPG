using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [Header("Unity Event")]
    public UnityEvent OnInteract;

    public void Interact(){

        OnInteract.Invoke();
    }
}
