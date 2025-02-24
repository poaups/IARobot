using UnityEngine;

public class Door : MonoBehaviour, IInteraction
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool canOpen;

    public void OnInteract()
    {
        if(canOpen)
        {
            OpenDoor();
            print("J'interagis la" + this.gameObject.name);
        }
    }

    void OpenDoor()
    {
        print("OpenDoor");
        animator.SetBool("CanOpen", true);
    }

    public void SetCanOpen(bool newValue)
    {
        canOpen = newValue;
    }
}
