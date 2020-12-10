using UnityEngine;
using UnityEngine.AI;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public bool UsingMaxDistance = false;

        [Space]
        public float MaxDestinationDistance;

        public NavMeshAgent Agent => GetComponent<NavMeshAgent>();

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit) && CanSetDestination(hit.point))
                {
                    Agent.SetDestination(hit.point);
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