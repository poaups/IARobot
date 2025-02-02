using UnityEngine;

public class ForwardPlayer : MonoBehaviour
{
    [SerializeField] private StarterAssetsInputs inputScript;
    [SerializeField] private PlayerInteraction interactionScript;
    [SerializeField] private ShelfManager shelfManagerScript;
    [SerializeField] private PlayerInteraction playerInteractionScript;

    private GameObject goTriggered;
    private bool alreadyTaken;
    private void Awake()
    {
        alreadyTaken = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other != null && other.GetComponent<ItemTP>() != null)
        {
            goTriggered = other.gameObject;
            interactionScript.SetTakeBox(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.GetComponent<ItemTP>() != null)
        {
            goTriggered = null;
            interactionScript.SetTakeBox(false);

        }
    }

    private void Update()
    {
        if(inputScript.isInteracting && goTriggered != null && !alreadyTaken)
        {
           // print("E");
            SetBoxOnPLayer();
        }
    }
    void SetBoxOnPLayer()
    {
       // print("SetBoxOnPLayer");
        alreadyTaken = true;
        goTriggered.GetComponent<FollowingGO>().StartFollowing();
        shelfManagerScript.SetObjectMesh(true);
        playerInteractionScript.SetTakeBox(true);
    }
}
