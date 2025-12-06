using Unity.Netcode;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : NetworkBehaviour
{
    private NetworkVariable<int> number = new NetworkVariable<int>(1);
    private NavMeshAgent agent;
    private Camera cam;
    [SerializeField] private LayerMask groundLayer; 

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }
    
    private void Update()
    {
        if (!IsOwner) return;

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f, groundLayer))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
