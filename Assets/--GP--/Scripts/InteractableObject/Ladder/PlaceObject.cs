using UnityEngine;

public class PlaceObject : MonoBehaviour, IInteraction
{
    [SerializeField] Material originalLadderMat;    
    public void OnInteract()
    {
        interaction();
    }

    void interaction()
    {
        GetComponent<BoxCollider>().isTrigger = false;
        GetComponent<MeshRenderer>().material = originalLadderMat;
    }
}
