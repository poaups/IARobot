using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrap : MonoBehaviour
{

    void OnTriggerEnter()
    {
        Gamemanager.instance.AddScrap();
        Destroy(this);
    }
}
