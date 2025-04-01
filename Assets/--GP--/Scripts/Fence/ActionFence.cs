using UnityEngine;

public class ActionFence : MonoBehaviour, IInteraction
{
    [SerializeField] private ActionEndAnimation actionAnim;
    [SerializeField] private bool forward;
    [SerializeField] private Transform finalPosForward;
    [SerializeField] private Transform finalPosBackward;
    [SerializeField] private GameObject otherTrigger;

    public void OnInteract()
    {
        // When the animation ends, the script adjusts the transform.
        // The transform represents the position where the player needs to be teleported, 
        // so we adjust it accordingly.
        if(Gamemanager.instance.InteractionPlayer.GetPliers())
        {
            if (forward)
            {
                actionAnim.finalPosFence = finalPosForward;
            }
            else
            {
                actionAnim.finalPosFence = finalPosBackward;
            }

            Gamemanager.instance.PlayerAnimation.SetAnimFence(true);
            otherTrigger.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            print("No item");
        }
    }
}
