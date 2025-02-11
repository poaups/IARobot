using UnityEngine;

public class Door : MonoBehaviour, IInteraction
{
    [SerializeField] private Animator animator;

    public void OnInteract()
    {
        OpenDoor();
        print("J'interagis la" + this.gameObject.name); 
    }

    void OpenDoor()
    {
        print("OpenDoor");
        animator.SetBool("CanOpen", true);
    }
}
