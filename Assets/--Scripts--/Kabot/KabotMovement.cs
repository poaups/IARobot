using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

public class KabotMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float rayLength = 1.5f;
    [SerializeField] private GameObject player;

    [HideInInspector] public float Speed;

    private NavMeshAgent agent;
    private Quaternion lastRotation;

    public enum KabotState
    {
        FollowPlayer,
        GuidePlayer,
        Sit
    }

    public KabotState CurrentState;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (CurrentState == KabotState.FollowPlayer)
        {
            target.position = player.transform.position;

            agent.destination = target.position;
            Speed = agent.velocity.magnitude;

            if (Speed > .01f)
            {
                Ray ray = new Ray(transform.position, Vector3.down);
                if (Physics.Raycast(ray, out RaycastHit hitInfo, rayLength, groundLayer))
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
            }
            else
            {
                transform.rotation = lastRotation;
            }
        }
        else
        {
            print("false");
        }
    }
}
