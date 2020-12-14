using Interaction;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerInteract : MonoBehaviour
    {
        private List<Interactable> interactables = new List<Interactable>();

        private Interactable ClosestInteractable;

        private Interactable TargetInteractable;

        private bool MovingToInteract = false;

        private bool WithinInteractionDistance => Vector3.Distance(transform.position, ClosestInteractable.transform.position) <= ClosestInteractable.InteractionDistance;

        private bool CanInteract => ClosestInteractable != null && WithinInteractionDistance;

        private void Awake()
        {
            GetAllInteractables();
        }

        private void Update()
        {
            GetClosestInteractableObject();

            if (MovingToInteract && ClosestInteractable == TargetInteractable && CanInteract)
            {
                ClosestInteractable.Interact();
                MovingToInteract = false;
            }

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.GetComponent<Interactable>())
                {
                    if (CanInteract)
                    {
                        ClosestInteractable.Interact();
                        Debug.Log($"Player has interacted with {ClosestInteractable} by click");
                    }
                    else
                    {
                        MoveToInteractable(hit.collider.gameObject.GetComponent<Interactable>());
                        Debug.Log($"Player wants to interact with {ClosestInteractable} by click");
                    }
                }
            }

            if (CanInteract && Input.GetKeyDown(ClosestInteractable.InteractionKey))
            {
                ClosestInteractable.Interact();
                Debug.Log($"Player has interacted with {ClosestInteractable}");
            }
        }

        private void MoveToInteractable(Interactable targetInteractable)
        {
            TargetInteractable = targetInteractable;

            if (Vector3.Distance(transform.position, TargetInteractable.transform.position) <= PlayerManager.Instance.PlayerController.MaxDestinationDistance)
            {
                MovingToInteract = true;
                PlayerManager.Instance.PlayerController.Agent.destination = TargetInteractable.transform.position;
            }
            else
            {
                Debug.Log($"Player is not in movement range to interact with {TargetInteractable}");
            }
        }

        private void GetClosestInteractableObject()
        {
            foreach (var interactable in interactables)
            {
                if (ClosestInteractable == null)
                {
                    ClosestInteractable = interactable;
                }

                if (Vector3.Distance(transform.position, interactable.transform.position) <= Vector3.Distance(transform.position, ClosestInteractable.transform.position))
                {
                    ClosestInteractable = interactable;
                }
            }
        }

        private void GetAllInteractables()
        {
            foreach (var interactable in FindObjectsOfType<Interactable>())
            {
                interactables.Add(interactable);
            }
        }
    }
}