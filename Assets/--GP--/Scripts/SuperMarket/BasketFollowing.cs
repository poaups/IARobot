using UnityEngine;

public class BasketFollowing : MonoBehaviour
{
    [SerializeField] private Vector3 offSet;
    [SerializeField] private Transform target;

    private void LateUpdate()
    {
        transform.position = target.TransformPoint(offSet);
        transform.rotation = target.rotation;
    }
}
