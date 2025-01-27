using UnityEngine;

public class TraversableObject : MonoBehaviour
{
    [SerializeField] private Transform finalPosition; 
    [SerializeField] private float speed = 5f;

    public Transform playerTransform;

    private bool isMoving = false;

    private void Update()
    {
        playerTransform.position = Vector3.MoveTowards(playerTransform.position, finalPosition.position, speed * Time.deltaTime);

        if (Vector3.Distance(playerTransform.position, finalPosition.position) < 0.1f)
        {
            isMoving = false; 
            Debug.Log("Arrivé à la cible !");
        }

     }
    
}
