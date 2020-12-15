using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class CursorBehaviour : MonoBehaviour
{
    public Texture2D clickableCursor;
    public Texture2D normalCursor;

    

    private void OnMouseOver()
    {
        if (PlayerManager.Instance.PlayerController.CanSetDestination(transform.position))
        { 
            Cursor.SetCursor(clickableCursor, Vector2.zero, CursorMode.Auto);
        }
    }

    private void OnMouseExit()
    {   
        Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.Auto);
    }
}
