using UnityEngine;
using UnityEngine.AI;

public class KabotMovement : MonoBehaviour
{
    [HideInInspector] public bool onTarget = false;

    [Header("Target")]
    [SerializeField] private Transform target;
    [SerializeField] private Transform smoothTarget;
    [SerializeField] private Transform door;

    [Header("Ray")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float rayLength = 1.5f;

    [SerializeField] private GameObject txtAbove;

    [HideInInspector] public float Speed;
    [HideInInspector] public bool IsPlayerNear;
    public float SmoothSpeed = 5f;

    private NavMeshAgent agent;
    private GameObject player;
    private Quaternion lastRotation;
    private SphereCollider nearTrigger;

    public enum KabotState
    {
        FollowPlayer,
        GuidePlayer,
        Obey
    }

    public KabotState CurrentState;

    private void Awake()
    {
        if (txtAbove != null)
        {
            txtAbove.SetActive(false);
        }
    }
    void Start()
    {
        player = Gamemanager.instance.Player;
        agent = GetComponent<NavMeshAgent>();
        nearTrigger = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            IsPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            IsPlayerNear = false;
        }
    }

    void Update()
    {
        MoveSmoothTarget();

        CheckStates();

        CheckOnTarget();

        SetOrientation();

        //Debug
        if(Input.GetKeyDown(KeyCode.R))
        {
           // target = testTarget;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
           // SetState(KabotState.DontMove);
        }
    }

    private void CheckOnTarget()
    {
        print(onTarget);
        if(Vector3.Distance(transform.position, target.position) < 0.5)
        {
            onTarget = true;
        }
        else
        {
            onTarget= false;
        }
    }

    private void MoveSmoothTarget()
    {
        if (Vector3.Distance(smoothTarget.transform.position, target.position) > 0.1f)
        {
            agent.destination = smoothTarget.position;
        }

        Speed = agent.velocity.magnitude;
    }

    private void CheckStates()
    {
        switch (CurrentState)
        {
            case KabotState.FollowPlayer:
                target.position = player.transform.position;
                print(target.position);
                print(player.transform.position);

                if (Vector3.Distance(smoothTarget.transform.position, target.position) > 2f)
                {
                    MoveSmoothTargetToTarget();
                }
                break;
            case KabotState.GuidePlayer:
                MoveSmoothTargetToTarget();
                break;
            default:
                Debug.LogWarning("État inconnu !");
                break;
        }
    }

    private void MoveSmoothTargetToTarget()
    {
        Vector3 direction = (target.position - smoothTarget.transform.position).normalized;
        smoothTarget.transform.position += direction * SmoothSpeed * Time.deltaTime;
    }

    private void SetOrientation()
    {
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

    public void SetState(KabotState state)
    {
        CurrentState = state;
    }
    public void ReturnToPlayer()
    {
        smoothTarget = player.transform;
    }
    
    public void DoorTarget()
    {
        target = door;
    }

    public void Obey()
    {
        //print("Obey");
    }
}
