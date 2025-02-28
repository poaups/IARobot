using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private bool hasKeys;
    private bool canTakeBox;
    private void Awake()
    {
        canTakeBox = false;
    }

    public void SetTakeBox(bool newBool)
    {
        canTakeBox = newBool;
    }
    public bool HasBox()
    {
        return canTakeBox;
    }
    public bool HasKey()
    {
        return hasKeys;
    }
}
