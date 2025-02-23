using UnityEngine;

public class TriggerTraversableObject : MonoBehaviour
{
    [SerializeField] private Transform targetFinal;
    [SerializeField] private MoveToward moveObject;

    private void OnTriggerEnter(Collider other)
    {
        if(other != null && other.GetComponentInChildren<PlayerMovement>() != null)
        {
            if(moveObject.GetCanMove())
            {
                moveObject.InverseColliderActivation();
                moveObject.SetTarget(targetFinal);
                moveObject.SetCanMove(true);
            }
        }
    }
}
