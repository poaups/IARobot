using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerObey : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.GetComponent<PlayerMovement>() != null)
        {
            Gamemanager.instance.InteractionPlayer.CanObey = true;
        }
    }
}
