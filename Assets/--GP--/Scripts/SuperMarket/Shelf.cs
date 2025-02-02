using UnityEngine;

public class Shelf : MonoBehaviour
{
    [SerializeField] private Transform finalPositionItem;
    [SerializeField] private ItemTP ItemTPScript;
    [SerializeField] private MeshRenderer wireFrame;
    [SerializeField] private Counter counterScript;
    [SerializeField] private int value;

    private bool alreadyUse;
    private void Awake()
    {
        alreadyUse = false;
    }
    public void UseObject()
    {
        //print("UseObject");
        //print("alreadyUse, il doit etre faux : " + alreadyUse);
        //print(!ItemTPScript.IsEmpty() + "Je dois etre faux list");

        if (!alreadyUse && ItemTPScript.IsEmpty())
        {
            print("Je vais ici");
            alreadyUse = true;
            ItemTPScript.TpItemToSetPosition(finalPositionItem);
            RemoveWireFrame();
            counterScript.AddValue(value);

        }
    }
    void RemoveWireFrame()
    {
        wireFrame.enabled = false;
    }
    public bool GetAlreadyUse()
    {
        return alreadyUse;
    }
}
