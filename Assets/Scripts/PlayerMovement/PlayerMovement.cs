using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool physics;
    public float movementSpeed;
    public float rotationSpeed;

    private Rigidbody rb;
    private void Start()
    {
        if (physics) rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (physics)
        {
            if (Input.GetKey(KeyCode.W)) rb.AddForce((transform.forward * movementSpeed));
            if (Input.GetKey(KeyCode.S)) rb.AddForce((-transform.forward * movementSpeed));
            if (Input.GetKey(KeyCode.A)) rb.AddForce((-transform.right * movementSpeed));
            if (Input.GetKey(KeyCode.D)) rb.AddForce((transform.right * movementSpeed));
            
        }
        else
        {
            BasicWasdMovement();
        }
        
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
