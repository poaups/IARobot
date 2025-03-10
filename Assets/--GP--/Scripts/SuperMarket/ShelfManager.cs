//using System.Collections.Generic;
//using UnityEngine;

//public class ShelfManager : MonoBehaviour
//{
//    [SerializeField] private List<MeshRenderer> allMeshs;
//    [SerializeField] private List<TriggerShelf> allTriggers;

//    private void Awake()
//    {
//        SetWireframe(false);
//    }
//    public void AbleAllShelf()
//    {
//        foreach (TriggerShelf shelfScript in allTriggers)
//        {
//            shelfScript.IsDepositBox();
//        }
//    }

//    public void SetWireframe(bool newValue)
//    {
//        for (int i = 0; i < allMeshs.Count; ++i)
//        {
//            //Probablement shader wireframe ici
//            allMeshs[i].enabled = newValue;
//        }
//    }
//}
