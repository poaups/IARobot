using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager instance;

    private bool something;
    private void Awake()
    {
        instance = this;
    }

    public void PickDown()
    {
        if(something)
        {
            truc();
        }
        Gamemanager.instance.SetCanMove(true);
        Gamemanager.instance.PlayerMovementScript.SetAnimationPickDown(false);
    }

    void truc()
    {

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
