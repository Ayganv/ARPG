using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class CursorBehaviour : MonoBehaviour
{
    public Texture2D clickableCursor;
    public Texture2D normalCursor;
    private Transform _playerTransform;
    private void Start()
    {
        Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (PlayerManager.Instance.PlayerController.MaxDestinationDistance <= Vector3.Distance(transform.position, _playerTransform.position))
        { 
            Cursor.SetCursor(clickableCursor, Vector2.zero, CursorMode.ForceSoftware);
        }
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.ForceSoftware);
    }
}
