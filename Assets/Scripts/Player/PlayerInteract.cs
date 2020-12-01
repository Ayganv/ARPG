using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{   
    [Header("Player Interaction Key")]
    public KeyCode InteractionKey;

    [Header("Interaction Settings")]
    public float InteractionDistance;

    private GameObject ClosestInteractableObject; 

    private bool CanInteract => ClosestInteractableObject != null && Vector3.Distance(transform.position, ClosestInteractableObject.transform.position) <= InteractionDistance;

    private void Update() {

        UpdateClosestInteractableobject();

        if(Input.GetKeyDown(InteractionKey) && CanInteract){

            Debug.Log($"You have interacted with {ClosestInteractableObject.name}");
            ClosestInteractableObject.GetComponent<Interactable>().Interact();
        }
    }

    public void UpdateClosestInteractableobject(){

        foreach (var interactable in FindObjectsOfType<Interactable>())
        {
            if(Vector3.Distance(transform.position, interactable.transform.position) <= InteractionDistance){

                if(ClosestInteractableObject == null){

                    ClosestInteractableObject = interactable.gameObject;
                    break;
                }else if(Vector3.Distance(transform.position, interactable.transform.position) < Vector3.Distance(transform.position, ClosestInteractableObject.transform.position)){

                    ClosestInteractableObject = interactable.gameObject;
                    break;
                }
            }
        }
    }
}
