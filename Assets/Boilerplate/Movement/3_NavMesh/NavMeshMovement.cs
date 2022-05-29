using UnityEngine;
using UnityEngine.AI;

public class NavMeshMovement : MonoBehaviour
{
    NavMeshAgent _NavMeshAgent;

    private void Awake()
    {
        _NavMeshAgent = GetComponent<NavMeshAgent>();    
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) // If we hitted a collider, we move to this point or the nearest walkable area
            {
                Move(hit.point);
            }
        }
    }

    private void Move(Vector3 position)
    {
        _NavMeshAgent.SetDestination(position);
    }
}
