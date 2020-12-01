using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;

    private void Update()
    {
        BasicWasdMovement();
    }

    void BasicWasdMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(horizontal, 0,vertical);
        if (horizontal != 0 || vertical != 0)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement),
                Time.deltaTime * rotationSpeed);
        
        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
    }
    /*public float movementSpeed;

    public KeyCode forwardKey;
    public KeyCode backwardKey;
    public KeyCode leftKey;
    public KeyCode rightKey;
    
    void Update()
    {
        if (Input.GetKey(forwardKey)) transform.position += new Vector3(0,0,movementSpeed * Time.deltaTime);
        if (Input.GetKey(backwardKey)) transform.position += new Vector3(0,0,-movementSpeed * Time.deltaTime);
        if (Input.GetKey(leftKey)) transform.position += new Vector3(-movementSpeed * Time.deltaTime,0,0);
        if (Input.GetKey(rightKey)) transform.position += new Vector3(movementSpeed * Time.deltaTime,0,0);
        
    }*/
}
