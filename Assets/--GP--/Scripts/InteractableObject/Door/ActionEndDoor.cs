using UnityEngine;

public class ActionEndDoor : MonoBehaviour
{
    private KabotMovement kaboot;

    private void Awake()
    {
        kaboot = Gamemanager.instance.KabotMovementScript;
    }
}
