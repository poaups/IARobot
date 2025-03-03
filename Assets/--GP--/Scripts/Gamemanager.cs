using UnityEngine;
public class Gamemanager : MonoBehaviour
{
    [Header("Objects")]
    public static Gamemanager instance;
    public GameObject Player;
    public GameObject Kabot;
    public GameObject PlayerController;
    
    [Header("Scripts")]
    public StarterAssetsInputs Mapping;
    public PlayerInteraction InteractionPlayer;
    public PlayerMovement ControllerPlayer;
    public KabotMovement KabotMovementScript;
    public TPSCameraController CameraMovement;
    public StarterAssetsInputs starterAssetsInputs;
    public Notification NotificationScript;

    [Header("Value")]
    public bool CanMove;

    private void Awake()
    {
        instance = this;
    }
    public void SetCanMove(bool newValue)
    {
        CanMove = newValue;
    }
    public void AbleControllerCamera()
    {
        starterAssetsInputs.enabled = true;
    } 
    public void SetCursor(bool newValue)
    {
        Cursor.visible = newValue;
    }

    public void SetPause(bool newValue)
    {
        if(newValue)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
