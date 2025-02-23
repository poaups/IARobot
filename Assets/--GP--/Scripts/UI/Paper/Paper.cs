using UnityEngine;

public class Paper : MonoBehaviour
{
    [SerializeField] private GameObject canvaPaper;



    private void Awake()
    {
        canvaPaper.SetActive(false);
    }
    public void SetDisplayPaper()
    {
        print("Display");
        canvaPaper.SetActive(!canvaPaper.activeSelf);
    }
}
