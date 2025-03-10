using UnityEngine;
using static KabotMovement;

public class SavePaw : MonoBehaviour, IInteraction
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

            Gamemanager.instance.SetCanMove(false);

            //New target on the transform in "newtarget" variable
            Gamemanager.instance.KabotMovementScript.SetTarget(targetToGo);
            Gamemanager.instance.KabotMovementScript.SetState(KabotState.NewTarget);

            Gamemanager.instance.PlayerMovementScript.SetAnimationUpdate(true);

            //replace wireframe by new mat here
            print("Sauve kaboot");
            alreadyUpdate = true;
        }

    }
}
