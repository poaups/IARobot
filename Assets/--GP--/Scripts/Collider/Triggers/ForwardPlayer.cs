//using UnityEngine;

//public class ForwardPlayer : MonoBehaviour
//{
//    [SerializeField] private StarterAssetsInputs inputScript;
//    [SerializeField] private PlayerInteraction interactionScript;
//    [SerializeField] private ShelfManager shelfManagerScript;
//    [SerializeField] private PlayerInteraction playerInteractionScript;

//    private GameObject goTriggered;
//    private bool alreadyTaken;
//    private void Awake()
//    {
//        alreadyTaken = false;
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        //if(other != null  && other.GetComponent<ItemTP>() != null)
//        //{
//        //    print(other.name);
//        //    goTriggered = other.gameObject;
//        //    interactionScript.SetTakeBox(true);
//        //}
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        //if (other != null && other.GetComponent<ItemTP>() != null)
//        //{
//        //    goTriggered = null;
//        //    interactionScript.SetTakeBox(false);

//        //}
//    }

//    private void Update()
//    {
//       // print(goTriggered);
//        if(inputScript.Interaction && goTriggered != null && !alreadyTaken)
//        {
//            print("E");
//            SetBoxOnPLayer();
//        }
//    }
//    void SetBoxOnPLayer()
//    {
//       print("SetBoxOnPLayer");
//        alreadyTaken = true;
//        goTriggered.GetComponent<FollowingGO>().StartFollowing();
//        shelfManagerScript.SetWireframe(true);
//        playerInteractionScript.SetTakeBox(true);
//    }
//}
