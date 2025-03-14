using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager instance;
    private void Awake()
    {
        instance = this;
    }

    public void PickDown()
    {
        Gamemanager.instance.SetCanMove(true);
        Gamemanager.instance.PlayerMovementScript.SetAnimationPickDown(false);
    }

    public void UpdateDog()
    {
        Gamemanager.instance.updateKaboot.Paw = true;
        Gamemanager.instance.SetCanMove(true);
        Gamemanager.instance.PlayerMovementScript.SetAnimationUpdate(false);
        Gamemanager.instance.SetEndAnimUpdate(true);
    }

    public void Door(Animator animator)
    {
        animator.SetBool("CanOpen", false);
        animator.enabled = false;
    }

    public void Pick()
    {
        Gamemanager.instance.SetCanMove(true);
        Gamemanager.instance.PlayerMovementScript.SetAnimationPick(false);
    }
}
