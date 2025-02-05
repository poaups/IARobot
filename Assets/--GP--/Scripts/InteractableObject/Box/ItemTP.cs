using System.Collections.Generic;
using UnityEngine;

public class ItemTP : MonoBehaviour
{
    [SerializeField] private List<GameObject> items;
    [SerializeField] private List<Transform> positionForItems;
    [SerializeField] private EndActivity endActivityScript;

    private FollowingGO followingGOScript;

    private bool listEmpty;
    private int lowerNumber = 0;
    private void Awake()
    {
        followingGOScript = GetComponent<FollowingGO>();
        if (items.Count >0)
        {
            listEmpty = false;
        }
        else
        {
            listEmpty = true;
        }

        TpItemToInitialPosition();
    }

    public bool IsNotEmpty()
    {
        if (items.Count > 0) return true;
        else return false;
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
        items[items.Count - 1].transform.position = newPosForItem.position;
        items.Remove(items[items.Count - 1]);
        
        if(!IsNotEmpty())
        {
            EndActivity();
        }
    }

    void EndActivity()
    {
        //print("Plus rien dans la liste");
        followingGOScript.SetActivity();
        endActivityScript.EndAction();
    }
    public bool ItemsIsEmpty()
    {
        if(items.Count == 0) return true;
        else return false;
    }
}
