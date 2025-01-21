using System.Collections.Generic;
using UnityEngine;

public class ItemTP : MonoBehaviour
{
    [SerializeField] private List<GameObject> items;
    [SerializeField] private List<Transform> positionForItems;

    private int lowerNumber = 0;
    private void Awake()
    {
        TpItemToInitialPosition();
    }

    //Tp item transform to holder transform
    void TpItemToInitialPosition()
    {
        if(positionForItems.Count > items.Count)
        {
            print("Trop de position " + positionForItems.Count + "  pour le nombre d'objets");
        }
        else if (items.Count > positionForItems.Count)
        {
            print("Trop d'items " + items.Count + "pour le nombre de position");
        }

        //For not have IndexOutOfRange Error
        lowerNumber = Mathf.Min(items.Count, positionForItems.Count);

        for (int i = 0; i < lowerNumber; i++)
        {
            items[i].transform.position = positionForItems[i].position;
            items[i].transform.SetParent(this.transform, true);
        }
    }

    //Tp item to position set in shelf, remove from parent, remove in list of items
    public void TpItemToSetPosition(Transform newPosForItem)
    {
        items[items.Count - 1].transform.SetParent(null);
        items[items.Count-1].transform.position = newPosForItem.position;
        items.Remove(items[items.Count-1]);
    }

    public bool ItemsIsEmpty()
    {
        if(items.Count == 0) return true;
        else return false;
    }
}
