using UnityEngine;
public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public GameObject Player;
    public GameObject Kabot;
    public StarterAssetsInputs Mapping;
    public PlayerInteraction InteractionPlayer;
    public KabotMovement KabotMovementScript;

    private void Awake()
    {
        instance = this;
    }

}
