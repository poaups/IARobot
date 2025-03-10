//using UnityEngine;
//public class TriggerShelf : MonoBehaviour
//{
//    [SerializeField] private ItemTP ItemTPScript;

//    private GameObject triggered;
//    private Shelf shelf;
//    private bool alreadyUse;
//    private PlayerInteraction interactionPlayer;

//    private void Awake()
//    {
//        alreadyUse = false;
//        shelf = GetComponent<Shelf>();
//    }
//    private void Start()
//    {
//        interactionPlayer = Gamemanager.instance.InteractionPlayer;
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if(other != null && other.GetComponent<PlayerMovement>())
//        {
//            triggered = other.gameObject;
//            //print("JE touche le player via le shelf");
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other != null && other.GetComponent<PlayerMovement>())
//        {
//            triggered = null;
//           // print("Je sors du player via le shelf");
//        }
//    }
//    public void IsDepositBox()
//    {
//       // print("already use" + alreadyUse);
//       // print("Je vais ici");
//        bool answer = false;
//        if (triggered != null && !alreadyUse && ItemTPScript.IsNotEmpty() && interactionPlayer.HasBox())
//        {
//            print("If");
//            alreadyUse = true;
//            answer = true;
//            shelf.UseObject();
//        }
//        else
//        {
//            //print("Nooooooooooooooooooooooo");
//        }
//       // print(answer + "Use object E + collision shelf");
//    }

//}
