using UnityEngine;

public class Door : MonoBehaviour, IInteraction
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool canOpen;
    //[SerializeField] private bool canDoSomething;
    [SerializeField] private ActionEndDoor actionAtEnd;
    //[SerializeField] private Door openOtherDoor;

    public void OnInteract()
    {
        print("interact");
        if(canOpen)
        {
            OpenDoor();
        }
    }
    void OpenDoor()
    {
        animator.SetBool("CanOpen", true);

        if (actionAtEnd!= null)
        {
            actionAtEnd.Action();
        }
    }
    public void SetCanOpen(bool newValue)
    {
        canOpen = newValue;
    }
}
