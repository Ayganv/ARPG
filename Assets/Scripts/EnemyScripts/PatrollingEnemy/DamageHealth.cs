using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHealth : MonoBehaviour {
    
    public float movementSpeed;
    public float rotationSpeed;
    public int playerHealth = 30;
    public int damage = 10;

    void Start() {
        print("Your health is " + playerHealth);
    }

    void Update() {
        BasicWasdMovement();
    }

    void BasicWasdMovement() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(horizontal, 0,vertical);
        if (horizontal != 0 || vertical != 0)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement),
                Time.deltaTime * rotationSpeed);
        
        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
    }

    
 void OnCollisionEnter(Collision _collision) {
        if(_collision.gameObject.tag=="PatrollingEnemy") {
            playerHealth-=damage;
            print("PatrollingEnemy just decreased your health to " + playerHealth);
        }
    } 
}
