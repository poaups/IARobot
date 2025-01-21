using UnityEngine;

public class TriggerForward : MonoBehaviour
{
    [SerializeField] private ItemTP ItemTPScript;

    private GameObject goStocked = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Shelf>() != null)
        {
            goStocked = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (goStocked != null && goStocked == other.gameObject)
        {
            goStocked = null;
        }
    }
    private void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        if(Input.GetKeyDown(KeyCode.E) && goStocked != null && !ItemTPScript.ItemsIsEmpty())
        {
            goStocked.GetComponent<Shelf>().UseObject();
        }
    }
}
