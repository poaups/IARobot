using System.Collections.Generic;
using UnityEngine;

public class ShelfManager : MonoBehaviour
{
    [SerializeField] private List<MeshRenderer> allMesh;

    private void Awake()
    {
        SetWireframe(false);
    }
    public void SetWireframe(bool newValue)
    {
        for (int i = 0; i < allMesh.Count; ++i)
        {
            //Probablement shader wireframe ici
            allMesh[i].enabled = newValue;
        }
    }
}
