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

        private bool hasAnim;

        public NavMeshAgent Agent => GetComponent<NavMeshAgent>();

        public void Start(){
            anim = GetComponentInChildren<Animator>();
            hasAnim = anim!=null;
        }
        
        public void Update()
        {
            if (Agent.remainingDistance <= Agent.stoppingDistance)
            {
                if(hasAnim)
                    anim.SetBool("ToRun", false);
            }
            if (Input.GetMouseButtonDown(0))
            {
                if(hasAnim)
                    anim.SetBool("ToRun", true);
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit) && CanSetDestination(hit.point))
                {
                    Agent.SetDestination(hit.point);
                }
            }
        }

        public bool CanSetDestination(Vector3 point)
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