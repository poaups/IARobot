using System.Collections.Generic;
using UnityEditor.ShaderGraph.Drawing;
using UnityEngine;

public class ActionBusDriver : MonoBehaviour, IInteraction
{
    [SerializeField] private TriggerBusDriver trigger;
    [SerializeField] private List<string> listOfText;
    private bool alreadyTook = false;

    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void OnInteract()
    {
        if (!alreadyTook)
        {
            Gamemanager.instance.PlayerMovementScript.SetAnimationPick(true);
            Gamemanager.instance.SetCanMove(false);
            Gamemanager.instance.Memories.ListOfText = listOfText;
            alreadyTook = true;
            trigger.DisableFeedback();
        }


        //Destroy(GetComponent<BoxCollider>());
        //Gamemanager.instance.PlayerMovementScript.goStocked = null;
    }
}
