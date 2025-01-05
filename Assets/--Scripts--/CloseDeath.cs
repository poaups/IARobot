using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDeath : MonoBehaviour
{
    [SerializeField] private GameObject _deathImage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Close()
    {
        _deathImage.SetActive(false);
    }
}
