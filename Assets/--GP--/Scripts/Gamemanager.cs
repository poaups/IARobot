using UnityEngine;
public class Gamemanager : MonoBehaviour
{
    [Header("Objects")]
    public static Gamemanager instance;
    public GameObject Player;
    public GameObject Kabot;
    public GameObject PlayerGO;
    public Door doorToOpen;
    public Transform Mouth;
    
    [Header("Scripts")]
    public StarterAssetsInputs Mapping;
    public PlayerMovement PlayerMovementScript;
    public KabotMovement KabotMovementScript;
    public TPSCameraController CameraMovement;
    public StarterAssetsInputs starterAssetsInputs;
    public Notification NotificationScript;
    public UpgradeKaboot UpdatePawScript;
    public ParentItems parentPickObject;
    public UpgradeKaboot updateKaboot;
    public Interaction InteractionPlayer;
    public ObjectSave objectSavePlayer;
    public ActionEndAnimation animation;
    public PlayerAnim PlayerAnimation;
    public PowerUpTxt powerUpTxt;
    public MemoriesLauncher Memories;

    [Header("Value")]
    public bool CanMove;
    public bool Keys;
    public bool EndAnimationUpdate = false;
    public bool Perks;

    private bool changeNotif = true;

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
