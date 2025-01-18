using UnityEngine;
using UnityEngine.AI;

public class Kabot : MonoBehaviour
{
    [SerializeField] private Transform Target;
    private NavMeshAgent agent;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float rayLength = 1.5f;
    private Quaternion lastRotation;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.destination = Target.position;

        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, rayLength, groundLayer) && agent.velocity.magnitude > 0.01f)
        {
            Vector3 groundNormal = hitInfo.normal;
            Vector3 moveDirection = agent.velocity.normalized;

            Vector3 right = Vector3.Cross(Vector3.up, moveDirection).normalized;
            Vector3 alignedForward = Vector3.Cross(groundNormal, right).normalized;

            Quaternion targetRotation = Quaternion.LookRotation(alignedForward, groundNormal);
            transform.rotation = targetRotation;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            lastRotation = transform.rotation;
        }
        else
        {
            transform.rotation = lastRotation;
        }
    }
}
