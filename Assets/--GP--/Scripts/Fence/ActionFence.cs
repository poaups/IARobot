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
        if(forward)
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
        //Gamemanager.instance.PlayerMovementScript.SetTeleportation(finalPosBus);
    }
}
