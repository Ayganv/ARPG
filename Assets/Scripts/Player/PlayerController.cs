using UnityEngine;
using UnityEngine.AI;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Player Controller Settings")]
        public bool UsingMaxDistance = false;

        [Space]
        public float MaxDestinationDistance;

        private Animator PlayerAnimator => GetComponentInChildren<Animator>();

        public NavMeshAgent Agent => GetComponent<NavMeshAgent>();

        public void Update()
        {
            if (PlayerAnimator == null)
            {
                Debug.LogError("The player has no animator");

                return;
            }

            if (Agent.remainingDistance <= Agent.stoppingDistance)
            {
                PlayerAnimator.SetBool("ToRun", false);
            }

            if (Input.GetMouseButtonDown(0) && PauseMenu.instance.IsPaused == false)
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit) && CanSetDestination(hit.point))
                {
                    PlayerAnimator.SetBool("ToRun", true);

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