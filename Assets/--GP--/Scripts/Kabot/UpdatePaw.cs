using UnityEngine;
using static KabotMovement;

public class UpdatePaw : MonoBehaviour, IInteraction
{
    [SerializeField] private Transform targetToGo;
    private bool alreadyUpdate = false;
    public void OnInteract()
    {
        print("OnInteract");
        print(alreadyUpdate + "alreadyUpdate");
        print(Gamemanager.instance.Perk);
        if (alreadyUpdate == false && Gamemanager.instance.Perk == true)
        {
            alreadyUpdate = true;
            Gamemanager.instance.SetCanMove(false);
            Gamemanager.instance.PlayerMovementScript.SetAnimationUpdate(true);

            ////New target on the transform in "newtarget" variable
            //Gamemanager.instance.KabotMovementScript.SetTarget(targetToGo);
            //Gamemanager.instance.KabotMovementScript.SetState(KabotState.NewTarget);
            ////replace wireframe by new mat here
            //print("Sauve kaboot");
            //alreadyUpdate = true;
        }

    }

    public void UpdateDog()
    {
        //New target on the transform in "newtarget" variable
        Gamemanager.instance.KabotMovementScript.SetTarget(targetToGo);
        Gamemanager.instance.KabotMovementScript.SetState(KabotState.NewTarget);
        //replace wireframe by new mat here
    }
}
