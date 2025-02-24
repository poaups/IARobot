using UnityEngine;
public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public GameObject Player;
    public GameObject Kabot;
    public GameObject PlayerController;

    public StarterAssetsInputs Mapping;
    public PlayerInteraction InteractionPlayer;
    public PlayerMovement ControllerPlayer;
    public KabotMovement KabotMovementScript;
    public TPSCameraController CameraMovement;
    public StarterAssetsInputs starterAssetsInputs;
    public Notification NotificationScript;

    public bool CanMove;

    private void Awake()
    {
        instance = this;
        //DisableControllerCamera();
    }
    public void SetCanMove(bool newValue)
    {
        CanMove = newValue;
    }
    public void AbleControllerCamera()
    {
        starterAssetsInputs.enabled = true;
    }

}
