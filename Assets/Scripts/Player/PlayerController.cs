using UnityEngine;
using UnityEngine.AI;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private Animator anim;
        public bool UsingMaxDistance = false;

        [Space]
        public float MaxDestinationDistance;

        public NavMeshAgent Agent => GetComponent<NavMeshAgent>();

        public void Start()
        {
        anim = GetComponent<Animator>();
        }
        
        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit) && CanSetDestination(hit.point))
                {
                    Agent.SetDestination(hit.point);
                    anim.SetTrigger("ToRun");
                }
            }
        }

        private bool CanSetDestination(Vector3 point)
        {
            if (!UsingMaxDistance)
            {
                return true;
            }
            else
            {
                if (Vector3.Distance(transform.position, point) <= MaxDestinationDistance)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}