using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _allActivity;
    [SerializeField] private GameObject _panel;
    [SerializeField] private DogInteraction _dogScript;
    private int _numberOfActivityEnd = 0;

    public void AddEnd()
    {
        _numberOfActivityEnd++;
        if(_numberOfActivityEnd == _allActivity.Count)
        {
            print("Fin");
            _panel.SetActive(false);
            _dogScript._canImpulse = true;
        }
    }

}
