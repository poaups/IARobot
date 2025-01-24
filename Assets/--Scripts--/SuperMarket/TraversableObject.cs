using UnityEngine;

public class TraversableObject : MonoBehaviour
{
    [SerializeField] private Transform finalPosition; // Position cible
    [SerializeField] private float speed = 5f; // Vitesse de déplacement

    public Transform playerTransform; // Transform du joueur

    private bool isMoving = false; // Indique si le joueur est en train de se déplacer

    private void Update()
    {
        // Vérifier si la touche H est appuyée
        if (Input.GetKeyDown(KeyCode.H))
        {
            StartMovement();
        }

        // Effectuer le mouvement si activé
        if (isMoving)
        {
            MovePlayerTowardsTarget();
        }
    }

    private void StartMovement()
    {
        // Activer le mouvement
        isMoving = true;
        Debug.Log("Début du déplacement vers la cible.");
    }

    private void MovePlayerTowardsTarget()
    {
        // Déplacer le joueur vers la cible
        playerTransform.position = Vector3.MoveTowards(
            playerTransform.position,
            finalPosition.position,
            speed * Time.deltaTime
        );

        // Vérifier si le joueur est proche de la cible
        if (Vector3.Distance(playerTransform.position, finalPosition.position) < 0.1f)
        {
            isMoving = false; // Arrêter le mouvement
            Debug.Log("Arrivé à la cible !");
        }
    }
}
