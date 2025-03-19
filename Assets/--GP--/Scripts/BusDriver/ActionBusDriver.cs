using UnityEngine;

public class ActionBusDriver : MonoBehaviour, IInteraction
{
    public void OnInteract()
    {
        Gamemanager.instance.PlayerMovementScript.SetAnimationPick(true);
    }
    public void ActionEndAnimation()
    {
        Gamemanager.instance.powerUpTxt.SetTxtHolder(true, Gamemanager.instance.powerUpTxt.txtPowerUp);
    }
}
