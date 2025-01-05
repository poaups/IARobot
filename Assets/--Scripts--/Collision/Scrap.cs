using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrap : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other != null && other.gameObject.GetComponent<AnimatorManager>() != null)
        {
            print("col sxrap player");
            Gamemanager.instance.AddScrap(1);
            Destroy(gameObject);
        }
  
    }
}
