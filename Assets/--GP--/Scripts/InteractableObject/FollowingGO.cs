using UnityEngine;

public class FollowingGO : MonoBehaviour
{
    private Transform transformToFollow; 
    [SerializeField] private float distanceAhead;

    private bool canFollow;
    private bool endActivity;

    private void Awake()
    {
        endActivity = false;
        canFollow = false;
    }
    private void Start()
    {
        transformToFollow = Gamemanager.instance.Player.transform;
    }
    private void LateUpdate()
    {
        transformToFollow = Gamemanager.instance.Player.GetComponent<Transform>();
        if (canFollow)
        {
            if (transformToFollow != null)
            {
                Vector3 positionAhead = transformToFollow.position + transformToFollow.forward * distanceAhead;

                transform.rotation = transformToFollow.rotation;
                transform.position = positionAhead;
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape) && endActivity == true)
        {
            canFollow = false;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    public void StartFollowing()
    {
        canFollow = true;
    }

    public void SetActivity()
    {
        endActivity = true;
    }
}
