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
    [SerializeField] private Color txtiIFindObject;
    private Gamemanager gm;
    
    private bool isFinish;
    private void Awake()
    {
        isFinish = false;
        SetupTxt();
    }

    private void Start()
    {
        gm = Gamemanager.instance;
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
        txtItems[index].color = txtiIFindObject;
        minPick--;
        CheckIfTken();
        if (!isFinish && minPick == 0)
        {
            EndPickUp();
        }
    }

    public void CheckIfTken()
    {
        int currentindex = 0;
        foreach (bool obj in Items)
        {
            if (obj == false)
            {
                currentindex++;
            }
        }

        if(currentindex == 1 && Gamemanager.instance.updateKaboot.Healed == true)
        {
           // print("Il reste que un objet");
            gm.NotificationScript.SetNotification(gm.NotificationScript.Outside);
            //Chien nouvelle target
        }
        else
        {
           // print("Il reste plus d'un objet");
        }
    }
    void EndPickUp()
    {
        isFinish = true;
        gm.NotificationScript.SetNotification(notificationTxt);
        //("Fini debut gpe chien");
    }
}
