using UnityEngine;

public class Door : MonoBehaviour, IInteraction
{
    public void OnInteract()
    {
        //Fct OpenDoor
        print("J'interagis la" + this.gameObject.name); 
    }
}
