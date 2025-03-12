using UnityEngine;
public class Gamemanager : MonoBehaviour
{
    [Header("Objects")]
    public static Gamemanager instance;
    public GameObject Player;
    public GameObject Kabot;
    public GameObject PlayerGO;
    public Door doorToOpen;
    
    [Header("Scripts")]
    public StarterAssetsInputs Mapping;
    public PlayerMovement PlayerMovementScript;
    public KabotMovement KabotMovementScript;
    public TPSCameraController CameraMovement;
    public StarterAssetsInputs starterAssetsInputs;
    public Notification NotificationScript;
    public UpdatePaw UpdatePawScript;
    public ParentItems parentPickObject;
    public KabootUpdate updateKaboot;

    [Header("Value")]
    public bool CanMove;
    public bool Keys;
    public bool EndAnimationUpdate = false;

    private bool changeNotif = true;

    private void Awake()
    {
        instance = this;
    }

    public void SetEndAnimUpdate(bool newValue)
    {
        EndAnimationUpdate = newValue;
        if (UpdatePawScript != null) {
            UpdatePawScript.UpdateDog();
        }
    }

    //public void SetPerks(bool pawValue)
    //{
      
    //}

    public void SetKeys(bool keys)
    {
        Keys = keys;
        doorToOpen.SetCanOpen(keys);
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
