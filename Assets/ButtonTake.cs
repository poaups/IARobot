using UnityEngine;

public class ButtonTake : MonoBehaviour
{
    private GameObject objectToPick;
    private Transform positionObject;
    private GameObject currentObjectPick;
    [HideInInspector] public bool alreadyTook = false;   
    public void Take()
    {
        if(!alreadyTook)
        {
            print("Take if");
            alreadyTook = true;
            Gamemanager.instance.KabotMovementScript.SetTarget(positionObject);
            objectToPick.transform.position = Gamemanager.instance.Mouth.position;
            objectToPick.transform.SetParent(Gamemanager.instance.Mouth);
            currentObjectPick = objectToPick;
        }
        else
        {
            UnTake();
        }


    }

    public void GiveObject()
    {
        print("GiveObject");
        currentObjectPick.transform.SetParent(null);
        print(currentObjectPick.name);
    }
    void UnTake()
    {
        print("Untake");
        currentObjectPick.transform.SetParent(null);
       alreadyTook = false;
       Take();
    }
    public void SetObject(GameObject go)
    {
        objectToPick = go;
        positionObject = go.transform;

        print(objectToPick + ": new  objectToPick");
        print(positionObject + ": new positionObject");
    }
}
