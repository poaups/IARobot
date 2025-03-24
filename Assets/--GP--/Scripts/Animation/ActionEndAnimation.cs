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
        Gamemanager.instance.SetCanMove(true);
        Gamemanager.instance.PlayerMovementScript.SetAnimationUpdate(false);

        if(Gamemanager.instance.updateKaboot.Paw)
        {
            Gamemanager.instance.KabotMovementScript.DoorTarget();
            Gamemanager.instance.updateKaboot.Paw = false;
            Gamemanager.instance.updateKaboot.Scanner = true;
        }
        else if (Gamemanager.instance.updateKaboot.Scanner)
        {
            Gamemanager.instance.KabotMovementScript.ScannerTarget();
            Gamemanager.instance.updateKaboot.Scanner = false;
        }
    }

    public void Door(Animator animator)
    {
        animator.SetBool("CanOpen", false);
        animator.enabled = false;
    }

    public void FallingBusDriver(Animator animator)
    {
        Destroy(animator);
    }
    public void Pick()
    {
        print("Pick end");
        #region BusDriver

        Interactable busDriver = Gamemanager.instance.PlayerMovementScript.goStocked;
        if (busDriver != null)
        {
            print("!= buss");
            Gamemanager.instance.powerUpTxt.SetTxtHolder(true, Gamemanager.instance.powerUpTxt.txtMemories);
            Gamemanager.instance.powerUpTxt.SetMemories(true);
        }
        #endregion

        Gamemanager.instance.SetCanMove(true);
        Gamemanager.instance.PlayerMovementScript.SetAnimationPick(false);
    }

    public void Memories()
    {
        print("Memories");
        Gamemanager.instance.PlayerAnimation.SetAnimMemories(false);
        Gamemanager.instance.SetCanMove(true);
    }
    public void Fall()
    {
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
