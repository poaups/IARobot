using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    [SerializeField] private ShelfManager shelfManagerScript;

    private GameObject goTriggered;
    private StarterAssetsInputs mapping;
    private bool alreadyTook;
    private FollowingGO follower;

    private void Awake()
    {
        follower = GetComponent<FollowingGO>();
        alreadyTook = false;
    }
    private void Start()
    {
        mapping = Gamemanager.instance.Mapping;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other != null && other.GetComponent<PlayerMovement>())
        {
            //print(other.name + "je touche la");
            goTriggered = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.GetComponent<PlayerMovement>())
        {
           // print(other.name + "je sors la");
            goTriggered = null;
        }  
    }
    public void IsTakenBox()
    {
        bool answer = false;
        if(goTriggered != null && !alreadyTook)
        {
            answer = true;
            SetBoxOnPlayer();
        }
       // print(answer + "Prise de la caisse");
    }

    void SetBoxOnPlayer()
    {
        Gamemanager.instance.InteractionPlayer.SetTakeBox(true);
        follower.StartFollowing();
        shelfManagerScript.SetWireframe(true);
    }


}
