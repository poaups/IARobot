using UnityEngine;

public class ActionBusDriver : MonoBehaviour, IInteraction
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void OnInteract()
    {
        Gamemanager.instance.PlayerMovementScript.SetAnimationPick(true);
    }

    public void SetAnimationFall(bool newAnim)
    {
        animator.SetBool("Fall", newAnim);
    }
}
