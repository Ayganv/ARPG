using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacleController : MonoBehaviour{
    
    public Transform plane;

    private Transform cube;

    private Vector3 direction = Vector3.forward;
    // Start is called before the first frame update
    void Start(){
        cube = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update(){
        Vector3 distance = cube.position - plane.position ;
        //Debug.Log(distance);
        
        if (distance.z > 20){
            direction = Vector3.back;
        }

        if (distance.z < -20){
            direction = Vector3.forward;
        }
        cube.transform.position += direction * (2 * Time.deltaTime);
      
    }
}
