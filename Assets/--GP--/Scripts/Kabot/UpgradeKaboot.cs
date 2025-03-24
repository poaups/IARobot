using UnityEngine;
using static KabotMovement;

public class UpgradeKaboot : MonoBehaviour, IInteraction
{
    public bool Paw = false;
    public bool Scanner = false;
    public bool Healed = false;

    private bool alreadyUpdate = false;
    private Gamemanager gm;

    private void Start()
    {
        gm = Gamemanager.instance;
    }
    public void OnInteract()
    {
        print("Interact kaboot");
        if(Paw)
        {
            print("Paw");
            PreapredUpgrade();
            //AddPaw();
        }
        else if (Scanner && Gamemanager.instance.KabotMovementScript.onTarget)
        {
            print("SCAN");
            PreapredUpgrade();
        }
        else
        {
            print("Aucune Amelioration");
        }
    }

    //void AddPaw()
    //{
    //    print("Paw");
    //    //gm.parentPickObject.CheckIfTken();
    //}
    //void AddScanner()
    //{
    //    print("Scanner");
    //}

    void PreapredUpgrade()
    {
        gm.SetCanMove(false);
        gm.PlayerMovementScript.SetAnimationUpdate(true);
    }
}   

//on interact
//if (!alreadyUpdate && gm.updateKaboot.Paw)
//{
//    alreadyUpdate = true;
//    gm.SetCanMove(false);
//    gm.PlayerMovementScript.SetAnimationUpdate(true);
//    gm.updateKaboot.Healed = true;
//    gm.updateKaboot.Paw = false;
//    gm.parentPickObject.CheckIfTken();
//}