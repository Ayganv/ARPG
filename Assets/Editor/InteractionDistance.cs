using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Interaction
{
    [CustomEditor(typeof(Interactable))]
    public class InteractionDistance : Editor
    {
        private void OnSceneGUI()
        {
            Interactable interactObject = (Interactable)target;
            Handles.color = Color.blue;
            Handles.DrawWireDisc(interactObject.transform.position, Vector3.up, interactObject.InteractionDistance);
        }
    }
}
