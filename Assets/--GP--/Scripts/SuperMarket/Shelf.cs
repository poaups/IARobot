using UnityEngine;

public class Shelf : MonoBehaviour
{
    [SerializeField] private Transform finalPositionItem;
    [SerializeField] private ItemTP ItemTPScript;

    private bool alreadyUse;
    private void Awake()
    {
        alreadyUse = false;
    }
    public void UseObject()
    {
        if (!alreadyUse)
        {
            alreadyUse = true;
            ItemTPScript.TpItemToSetPosition(finalPositionItem);
        }
    }
}
