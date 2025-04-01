using UnityEngine;

public class SetParent : MonoBehaviour
{
    public void SetParentObject(Transform needToBeChild, Transform parent)
    {
        needToBeChild.SetParent(parent);
    }
}
