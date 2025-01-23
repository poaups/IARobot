using StarterAssets;
using UnityEngine;

public class TraversableObject : MonoBehaviour
{
    [SerializeField] private Transform finalPosition; // Position cible
    [SerializeField] private float speed; // Vitesse de déplacement

    [HideInInspector] public bool isTriggerFront = false;
    [HideInInspector] public bool CanTraverse;
    [HideInInspector] public bool test;

    private Transform playerTransform;

    private void Awake()
    {
        test = false;
        CanTraverse = false;
        isTriggerFront = false;
        playerTransform = LocalManager.instance.player.GetComponent<Transform>();
    }

    public void IsTrigger()
    {
        isTriggerFront = !isTriggerFront;
        print("isTrigger apres changement: " + isTriggerFront);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CanTraverse = true;
            print(CanTraverse + " : CanTraverse apres changement");
        }

        CanMovementForward();

        if (test)
        {
            MovementForward();
        }
    }

    void CanMovementForward()
    {
        if (isTriggerFront && CanTraverse)
        {
            LocalManager.instance.AbleDisableControllerLM();
            test = true;
        }
    }

    void MovementForward()
    {
        print("MovemForward");
        Vector3 direction = (finalPosition.position - playerTransform.position).normalized;
        playerTransform.position += direction * speed * Time.deltaTime;
        playerTransform.transform.forward = direction;

        if (Vector3.Distance(playerTransform.position, finalPosition.position) < 0.1f)
        {
            test = false;
            LocalManager.instance.AbleDisableControllerLM();
            print("Fin arrive");
        }
    }
}
