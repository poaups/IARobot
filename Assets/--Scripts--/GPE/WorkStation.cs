using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkStation : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    public void OpenDisablePanel()
    {
        print("OpenDisablePanel");
        Gamemanager.instance.AbleDisableControllers();
        _panel.SetActive(!_panel.activeSelf);
    }     

}
