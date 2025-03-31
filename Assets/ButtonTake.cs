using UnityEngine;

public class ButtonTake : MonoBehaviour
{
    private GameObject objectToPick;
    private Transform positionObject;
    public void Take()
    {
        Gamemanager.instance.KabotMovementScript.SetTarget(positionObject);

        //Il faut mettre l'objet dans la geule de kaboot quand il est sur l'objet, mettre un trigger sur les objet et le mettre a true ?

        //print(objectToPick + " objectToPick");
        //print(positionObject + " positionObject");
    }

    public void SetObject(GameObject go)
    {
        objectToPick = go;
        positionObject = go.transform;
    }
}
