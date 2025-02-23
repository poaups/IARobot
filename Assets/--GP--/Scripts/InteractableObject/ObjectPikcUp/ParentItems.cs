using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class ParentItems : MonoBehaviour
{
    public List<bool> Items = new List<bool>();
    [SerializeField] private List<string> nameItem = new List<string>();

    [SerializeField] private List<TextMeshProUGUI> txtItems = new List<TextMeshProUGUI>();
    [SerializeField] private string texte;
    [SerializeField] private int tolerance;
    
    private bool isFinish;
    private void Awake()
    {
        isFinish = false;
        tolerance += 1;
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

        if(!isFinish && IfSucces())
        {
            EndPickUp();
        }
    }

    bool IfSucces()
    {
        int ItemForFinish = Items.Count - tolerance;
        print(ItemForFinish);

        print(ItemForFinish);
        for (int i = 0; i < ItemForFinish; i++)
        {
            if (Items[i] != true)
            {
                return false;
            }
        }
        return true;
    }

    void EndPickUp()
    {
        isFinish = true;
        print("Fini debut gpe chien");
    }
}
