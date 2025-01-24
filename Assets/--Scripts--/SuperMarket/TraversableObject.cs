using UnityEngine;

public class TraversableObject : MonoBehaviour
{
    [SerializeField] private Transform finalPosition; // Position cible
    [SerializeField] private float speed = 5f; // Vitesse de d�placement

    public Transform playerTransform; // Transform du joueur

    private bool isMoving = false; // Indique si le joueur est en train de se d�placer

    private void Update()
    {
        // V�rifier si la touche H est appuy�e
        if (Input.GetKeyDown(KeyCode.H))
        {
            StartMovement();
        }

        // Effectuer le mouvement si activ�
        if (isMoving)
        {
            MovePlayerTowardsTarget();
        }
    }

    private void StartMovement()
    {
        // Activer le mouvement
        isMoving = true;
        Debug.Log("D�but du d�placement vers la cible.");
    }

    private void MovePlayerTowardsTarget()
    {
        // D�placer le joueur vers la cible
        playerTransform.position = Vector3.MoveTowards(
            playerTransform.position,
            finalPosition.position,
            speed * Time.deltaTime
        );

        // V�rifier si le joueur est proche de la cible
        if (Vector3.Distance(playerTransform.position, finalPosition.position) < 0.1f)
        {
            isMoving = false; // Arr�ter le mouvement
            Debug.Log("Arriv� � la cible !");
        }
    }
}
