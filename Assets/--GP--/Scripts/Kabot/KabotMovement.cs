using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

public class KabotMovement : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;
    [SerializeField] private Transform newTarget;
    [SerializeField] private Transform smoothTarget;

    [Header("Ray")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float rayLength = 1.5f;

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
        Obey,
        NewTarget,
        DontMove
    }

    public KabotState CurrentState;

    private void Awake()
    {
        SetState(KabotState.DontMove);
    }

    void Start()
    {
        player = Gamemanager.instance.PlayerController;
        Debug.Log(player.name);
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

        SetOrientation();

        //Debug
        if(Input.GetKeyDown(KeyCode.R))
        {
            SetTarget(newTarget);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            SetState(KabotState.DontMove);
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

                if (Vector3.Distance(smoothTarget.transform.position, target.position) > 2f)
                {
                    MoveSmoothTargetToTarget();
                }
                break;

            case KabotState.GuidePlayer:
                MoveSmoothTargetToTarget();
                break;
            case KabotState.NewTarget:
                NewTargetSetup();
                break;
            case KabotState.DontMove:
                NoMovement();
                break;
            default:
                Debug.LogWarning("État inconnu !");
                break;
        }
    }
    public void NoMovement()
    {
        Speed = 0;
        //Set animation later
    }

   public void NewTargetSetup()
    {
        smoothTarget.transform.position = newTarget.transform.position;
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
    public void SetTarget(Transform target)
    {
        SetState(KabotState.NewTarget);
    }
    public void ReturnToPlayer()
    {
        smoothTarget = player.transform;
    }


    public void Obey()
    {
        //print("Obey");
    }
}
