using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActionScanTrigger : MonoBehaviour
{
    [SerializeField] private GameObject scanUi;
    [SerializeField] private TextMeshProUGUI scanUiTxt;
    [SerializeField] private ButtonTake take;
    public void DisplayScan(GameObject other)
    {
        scanUi.SetActive(true);
        ModifyScan(other);
        take.SetObject(other.gameObject);

       // GameObject createdObjectUI = Instantiate(objectToCreate, spawn.position,Quaternion.identity);
       // createdObjectUI.transform.SetParent(canvaParent.transform);
       // createdObjectUI.GetComponentInChildren<ButtonTake>().SetObject(other.gameObject);
       // allInstance.Add(createdObjectUI);

        //DeleatLast();
        //ModifyInstance(createdObjectUI, other);
    }

    public void UnDisplay()
    {
        scanUi.SetActive(false);
        scanUiTxt.text = "";
    }
    void ModifyScan(GameObject other)
    {
        scanUiTxt.text = other.GetComponent<ScannableObject>().Name;
    }
}
