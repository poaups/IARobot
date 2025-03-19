using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// Action at end of any animation when function is called
/// </summary>
public class ActionEndAnimation : MonoBehaviour
{
    [SerializeField] private Transform finalPosBus;
    public Transform finalPosFence;
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
        ActionBusDriver busDriver = Gamemanager.instance.PlayerMovementScript.goStocked.GetComponent<ActionBusDriver>();
        if (busDriver != null)
        {
            busDriver.ActionEndAnimation();
        }
        Gamemanager.instance.SetCanMove(true);
        Gamemanager.instance.PlayerMovementScript.SetAnimationPick(false);
    }

    public void Fall()
    {
        print("Fin anim Fall");
        Gamemanager.instance.SetCanMove(true);
        Gamemanager.instance.PlayerMovementScript.SetAnimationFalling(false);
        Gamemanager.instance.PlayerMovementScript.SetTeleportation(finalPosBus);
    }
    public void Fence()
    {
        Gamemanager.instance.PlayerAnimation.SetAnimFence(false);
        Gamemanager.instance.PlayerMovementScript.SetTeleportation(finalPosFence);
    }
}
