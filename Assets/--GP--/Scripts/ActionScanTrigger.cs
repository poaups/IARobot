using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActionScanTrigger : MonoBehaviour
{
    [SerializeField] private GameObject objectToCreate;
    [SerializeField] private Transform spawn;
    [SerializeField] private Canvas canvaParent;
    [SerializeField] private int tolerance;
    [SerializeField] private int spacing;

    private List<GameObject> allInstance = new List<GameObject>();
    public void Instance(GameObject other)
    {
        GameObject createdObjectUI = Instantiate(objectToCreate, spawn.position,Quaternion.identity);
        createdObjectUI.transform.SetParent(canvaParent.transform);
        createdObjectUI.GetComponentInChildren<ButtonTake>().SetObject(other.gameObject);
        allInstance.Add(createdObjectUI);


        MovingUi();
        DeleatLast();
        ModifyInstance(createdObjectUI, other);
    }

    void MovingUi()
    {
        foreach(GameObject obj in allInstance)
        {
            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y - spacing, obj.transform.position.z);
        }
    }

    void DeleatLast()
    {
        
        if(allInstance.Count >= tolerance)
        {
            allInstance.Remove(allInstance[0]);
        }
    }
    void ModifyInstance(GameObject createdObject, GameObject go2)
    {
        createdObject.GetComponentInChildren<TextMeshProUGUI>().text = go2.GetComponent<ScannableObject>().Name;
    }
}
