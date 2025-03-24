using UnityEngine;
using static KabotMovement;

public class TriggerState : MonoBehaviour
{ 
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.GetComponent<PlayerMovement>() != null)
        {
            Gamemanager.instance.KabotMovementScript.CurrentState = KabotState.FollowPlayer;
        }
    }
}
