using UnityEngine;

public class Pliers : MonoBehaviour, IInteraction
{
    public void OnInteract()
    {
        Gamemanager.instance.InteractionPlayer.SetPliers(true);
    }
}
