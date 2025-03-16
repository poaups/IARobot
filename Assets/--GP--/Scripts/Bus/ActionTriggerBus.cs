using UnityEngine;

public class ActionTriggerBus : MonoBehaviour, IInteraction
{
    [SerializeField] private Transform desiredPos;
    [SerializeField] private GameObject ui;
    [SerializeField] private float speed;

    private bool canMoveToward;
    public void OnInteract()
    {
        print("Interact action bus");
        canMoveToward = true;
    }

    private void Update()
    {
        if (canMoveToward)
        {
            MoveToward();
        }
    }
    void MoveToward()
    {
        print("Movetoward");
        Gamemanager.instance.Player.transform.position = Vector3.MoveTowards(Gamemanager.instance.Player.transform.position, desiredPos.position, speed);
    }
    public void StartAction()
    {
        ui.SetActive(true);
    }

    public void DisableAction()
    {
        ui.SetActive(false);
    }
}
