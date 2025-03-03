using Unity.VisualScripting;
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
    //public Sensitivity MouseSettings;

    public bool CanMove;
    public float Sensitivity;

    //private DontDestroy settings;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        //DisableControllerCamera();
    }

    private void Start()
    {
        //PlayerPrefs.SetFloat("Sensitivity", Sensitivity);
        //PlayerPrefs.Save();

        //settings = GameObject.FindGameObjectWithTag("Settings").GetComponent<DontDestroy>();

        //if (settings != null)
        //{
        //    Debug.Log("Objet avec le tag 'Settings' trouvé : " + settings.name);
        //    Sensitivity = settings.value;
        //    // Ici tu peux ajouter des actions supplémentaires sur cet objet, comme accéder à ses composants
        //}
        //else
        //{
        //    Debug.Log("Aucun objet avec le tag 'Settings' trouvé.");
        //}
    }

    private void Update()
    {
      
        //Sensitivity = settings.value;
        //CameraMovement.SetSensitivity(Sensitivity);

        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    MouseSettings.SetSlider(Sensitivity);
        //}
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
