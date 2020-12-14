using Interaction;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerInteract : MonoBehaviour
    {
        private List<Interactable> interactables = new List<Interactable>();

        private Interactable ClosestInteractable;

        private bool WithinInteractionDistance => Vector3.Distance(transform.position, ClosestInteractable.transform.position) <= ClosestInteractable.InteractionDistance;

        private bool CanInteract => ClosestInteractable != null && WithinInteractionDistance;

        private void Awake()
        {
            GetAllInteractables();
        }

        private void Update()
        {
            GetClosestInteractableObject();

            if (CanInteract && Input.GetKeyDown(ClosestInteractable.InteractionKey))
            {
                ClosestInteractable.Interact();
                Debug.Log($"Player has interacted with {ClosestInteractable}");
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