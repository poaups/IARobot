using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LocalManager : MonoBehaviour
{
    public static LocalManager instance;
    public GameObject player;
    [SerializeField] private ThirdPersonController ControllerScript;

    private void Awake()
    {
        instance = this;
    }

    public void DisableControllerLM()
    {
        player.GetComponentInChildren<ThirdPersonController>().DisableController();
    }

    public void AbleControllerLM()
    {
        player.GetComponentInChildren<ThirdPersonController>().AbleController();
    }

}
