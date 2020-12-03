using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerInteract : MonoBehaviour
{   
    [Header("Player Interaction Key")]
    public KeyCode InteractionKey;

    [Header("Interaction Settings")]
    public float InteractionDistance;

    private Interactable InteractableTarget;

    private GameObject ClosestInteractableObject; 

    private bool CanInteract => ClosestInteractableObject != null && Vector3.Distance(transform.position, ClosestInteractableObject.transform.position) <= InteractionDistance;

    private void Update() {

        if(Input.GetMouseButtonDown(0)){

            GetInteractableTarget();
        }

        UpdateClosestInteractableobject();

        if(Input.GetKeyDown(InteractionKey) && CanInteract){

            Debug.Log($"You have interacted with {ClosestInteractableObject.name}");
            
            ClosestInteractableObject.GetComponent<Interactable>().Interact();
        }
    }

    public void UpdateClosestInteractableobject(){

        foreach (var interactable in FindObjectsOfType<Interactable>())
        {
            if(ClosestInteractableObject == null){

                ClosestInteractableObject = interactable.gameObject;
                break;
            }else if(Vector3.Distance(transform.position, interactable.transform.position) < Vector3.Distance(transform.position, ClosestInteractableObject.transform.position)){

                ClosestInteractableObject = interactable.gameObject;
                break;
            }
        }
    }

    public void GetInteractableTarget(){

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)){

            InteractableTarget = hit.collider.gameObject.GetComponent<Interactable>();
        }

        Debug.Log(InteractableTarget);
    }
}
