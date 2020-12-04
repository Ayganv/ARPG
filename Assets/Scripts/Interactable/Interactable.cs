using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Interaction
{
    public class Interactable : MonoBehaviour
    {
        [Header("Interaction Settings")]
        public KeyCode InteractionKey;

        [Space]
        public float InteractionDistance;

        [Header("Unity Event")]
        public UnityEvent OnInteract;

        public void Interact()
        {
            Debug.Log($"Player has interacted with {this}");
            OnInteract.Invoke();
        }
    }
}