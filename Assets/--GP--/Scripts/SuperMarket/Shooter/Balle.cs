using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : MonoBehaviour
{
    void Update()
    {
        transform.forward *= 2;
    }

    public void StartMoving(Transform player)
    {
        //print(player.name);
        transform.position = player.position;
    }
}
