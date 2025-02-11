using UnityEngine;

public class Paper : MonoBehaviour
{
    private bool canShowPaper;
    private void Awake()
    {
        canShowPaper = true;
    }
    public void DisplayPaper()
    {
        print("Display");
        canShowPaper = !canShowPaper;
    }
    public bool CanDisplay()
    {
        return canShowPaper;
    }
}
