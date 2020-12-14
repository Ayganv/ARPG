using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class CursorBehaviour : MonoBehaviour
{
    public Texture2D clickableCursor;
    public Texture2D normalCursor;
    private PlayerController _playerController;
    private Transform _playerTransform;
    private float _playerDistance;
    private void Start()
    {
        Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void Update()
    {
        _playerDistance = Vector3.Distance(transform.position, _playerTransform.position);
        if (_playerController.MaxDestinationDistance <= _playerDistance)
        {
            OnMouseOver();
        }
    }

    private void OnMouseOver()
    {
        Cursor.SetCursor(clickableCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.ForceSoftware);
    }
}
