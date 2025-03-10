using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class ParentItems : MonoBehaviour
{
    public List<bool> Items = new List<bool>();
    [SerializeField] private List<string> nameItem = new List<string>();

    [SerializeField] private List<TextMeshProUGUI> txtItems = new List<TextMeshProUGUI>();
    [SerializeField] private string texte;
    [SerializeField] private string notificationTxt;
    [SerializeField] private int minPick;
    
    private bool isFinish;
    private void Awake()
    {
        isFinish = false;
        SetupTxt();
    }
    void SetupTxt()
    {
        for (int i = 0; i < Items.Count; i++)
        {
            txtItems[i].text = texte + nameItem[i];
        }

        if(txtItems.Count > Items.Count)
        {
            for(int i = Items.Count ; i < txtItems.Count; i++)
            {
                Destroy(txtItems[i]);
            }
        }
    }
    public void ChangeBool(int index)
    {
        Items[index] = true;
        txtItems[index].color = Color.red;
        minPick--;

        if (!isFinish && minPick == 0)
        {
            EndPickUp();
        }
    }
    void EndPickUp()
    {
        isFinish = true;
        Gamemanager.instance.NotificationScript.SetNotification(notificationTxt);
        print("Fini debut gpe chien");
    }
}
