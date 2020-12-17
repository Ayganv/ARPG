using UnityEngine;
using UnityEngine.AI;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Player Controller Settings")]
        public bool UsingDistanceRestrictions = false;

        [Space]
        public float MaxDestinationDistance;
        public float MinDestinationDistance;

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
            var distance = Vector3.Distance(transform.position, point);

            if (!UsingDistanceRestrictions)
            {
                return true;
            }
            else
            {
                if (distance >= MinDestinationDistance && distance <= MaxDestinationDistance)
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