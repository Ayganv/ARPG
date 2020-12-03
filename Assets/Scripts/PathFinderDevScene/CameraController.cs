using UnityEngine;


public class CameraController : MonoBehaviour
{
    public GameObject targetObject;

    private Vector3 _offset;

    void Start(){

        _offset = targetObject.transform.position - transform.position;
    }

    void Update(){

        transform.position = targetObject.transform.position - _offset;
    }
}
