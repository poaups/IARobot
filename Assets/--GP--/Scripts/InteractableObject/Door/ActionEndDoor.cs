using UnityEngine;

public class ActionEndDoor : MonoBehaviour
{
    [SerializeField] private Transform newTargetkabot;
    private KabotMovement kaboot;

    private void Awake()
    {
        kaboot = Gamemanager.instance.KabotMovementScript;
    }
    public void Action()
    {
        kaboot.SetTarget(newTargetkabot);
    }
}
