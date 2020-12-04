using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerInteract : MonoBehaviour
{
    private Interactable InteractableTarget;

    private GameObject ClosestInteractableObject; 

    private NavMeshAgent agent => GetComponent<NavMeshAgent>();

    private bool MovingToInteract = false;

    private bool CanInteract(){

        if(InteractableTarget == null){

            return false;
        }

        if(Vector3.Distance(transform.position, ClosestInteractableObject.transform.position) <= InteractableTarget.InteractionDistance){

            return true;
        }else{

            return false;
        }
    }

    private void Update() {

        if(Input.GetMouseButtonDown(0)){
            
            GetInteractableTarget();
        }

        if(CanInteract() && MovingToInteract){

            InteractableTarget.Interact();
            MovingToInteract = false;
        }

        UpdateClosestInteractableobject();

        if(InteractableTarget != null && Input.GetKeyDown(InteractableTarget.InteractionKey) && CanInteract()){

            Debug.Log($"You have interacted with {ClosestInteractableObject.name}");
            
            ClosestInteractableObject.GetComponent<Interactable>().Interact();
        }
    }

    public void UpdateClosestInteractableobject(){

        foreach (var interactable in FindObjectsOfType<Interactable>())
        {
            if(ClosestInteractableObject == null){

                ClosestInteractableObject = interactable.gameObject;
                InteractableTarget = interactable;
                break;
            }else if(Vector3.Distance(transform.position, interactable.transform.position) < Vector3.Distance(transform.position, ClosestInteractableObject.transform.position)){

                ClosestInteractableObject = interactable.gameObject;
                InteractableTarget = interactable;
                break;
            }
        }
    }

    public void GetInteractableTarget(){

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)){

            InteractableTarget = hit.collider.gameObject.GetComponent<Interactable>();
            MoveToTarget(hit.point);
        }
    }   

    private void MoveToTarget(Vector3 targetPosition){

        MovingToInteract = true;
        agent.SetDestination(targetPosition);
    }
}
