using UnityEngine;

public class Shelf : MonoBehaviour
{
    [SerializeField] private Transform finalPositionItem;
    [SerializeField] private ItemTP ItemTPScript;
    [SerializeField] private MeshRenderer wireFrame;
    [SerializeField] private Counter counterScript;
    [SerializeField] private int value;

    public void UseObject()
    {
        print("UseObject dans Shelf");
        ItemTPScript.TpItemToSetPosition(finalPositionItem);
        RemoveWireFrame();
        counterScript.AddValue(value);
    }
    void RemoveWireFrame()
    {
        print("Wireframe changement");
        wireFrame.enabled = false;
    }
}
