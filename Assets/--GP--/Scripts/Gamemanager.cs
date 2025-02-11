using UnityEngine;
public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public GameObject Player;
    public GameObject Kabot;
    public StarterAssetsInputs Mapping;
    public PlayerInteraction InteractionPlayer;
    public Controller ControllerPlayer;
    public KabotMovement KabotMovementScript;
    public TPSCameraController CameraMovement;

    private void Awake()
    {
        instance = this;
        //DisableControllerCamera();
    }

    public void DisableControllerCamera()
    {
        CameraMovement.enabled = false;
        ControllerPlayer.enabled = false; 
    }

    public void AbleControllerCamera()
    {
        CameraMovement.enabled = true;
        ControllerPlayer.enabled = true;
    }

}
