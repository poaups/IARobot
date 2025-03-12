using UnityEngine;
using static KabotMovement;

public class UpdatePaw : MonoBehaviour, IInteraction
{
    [SerializeField] private Transform targetToGo;
    private bool alreadyUpdate = false;
    private Gamemanager gm;
    private void Start()
    {
        gm = Gamemanager.instance;
    }
    public void OnInteract()
    {
        if (alreadyUpdate == false && gm.updateKaboot.Paw == true)
        {
            alreadyUpdate = true;
            gm.SetCanMove(false);
            gm.PlayerMovementScript.SetAnimationUpdate(true);
            gm.updateKaboot.Healed = true;
            gm.updateKaboot.Paw = false;
            gm.parentPickObject.CheckIfTken();
        }

    }

    public void UpdateDog()
    {
        //New target on the transform in "newtarget" variable
        gm.KabotMovementScript.SetTarget(targetToGo);
        gm.KabotMovementScript.SetState(KabotState.NewTarget);
        //replace wireframe by new mat here
    }
}
