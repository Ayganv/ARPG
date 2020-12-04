using UnityEngine;

namespace PathFinderDevScene{
    public class JoelsCameraController : MonoBehaviour
    {
    
        public GameObject targetObject;


        private Vector3 _offset;
        // Start is called before the first frame update

        void Start(){

            _offset = targetObject.transform.position - transform.position;
        }

        // Update is called once per frame
        void Update(){

            transform.position = targetObject.transform.position - _offset;
        }
    }
}

