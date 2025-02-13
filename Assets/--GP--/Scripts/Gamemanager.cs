using UnityEngine;
public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public GameObject Player;
    public GameObject Kabot;
    public GameObject PlayerController;

    public StarterAssetsInputs Mapping;
    public PlayerInteraction InteractionPlayer;
    public Controller ControllerPlayer;
    public KabotMovement KabotMovementScript;
    public TPSCameraController CameraMovement;
    public StarterAssetsInputs starterAssetsInputs;

    private void Awake()
    {
        instance = this;
        //DisableControllerCamera();
    }

    public void DisableControllerCamera()
    {
        print("Oui");
        starterAssetsInputs.enabled = false; 
    }

    public void AbleControllerCamera()
    {
        starterAssetsInputs.enabled = true;
    }

}
