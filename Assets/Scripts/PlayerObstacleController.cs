using UnityEngine;
using UnityEngine.AI;

public class PlayerObstacleController : MonoBehaviour{
    
    private NavMeshAgent agent => GetComponent<NavMeshAgent>();
    
    public void Update(){

        if (Input.GetMouseButtonDown(0)){
            
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)){
                agent.SetDestination(hit.point);
            }
        }
    }
}
