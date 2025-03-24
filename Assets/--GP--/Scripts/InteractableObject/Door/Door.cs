using UnityEngine;

public class Door : MonoBehaviour, IInteraction
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool canOpen;

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
    }
    public void SetCanOpen(bool newValue)
    {
        canOpen = newValue;
    }
}
