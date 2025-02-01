using UnityEngine;

public class FollowingGO : MonoBehaviour
{
    [SerializeField] private Transform transformToFollow; 
    [SerializeField] private float distanceAhead;

    private void Awake()
    {
        this.enabled = false;  // Si vous voulez désactiver au début
    }

    private void LateUpdate()
    {
        if (transformToFollow != null)
        {
            Vector3 positionAhead = transformToFollow.position + transformToFollow.forward * distanceAhead;

            transform.rotation = transformToFollow.rotation;
            transform.position = positionAhead;
        }
    }
}
