using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class ParentItems : MonoBehaviour
{
    public List<bool> Items = new List<bool>();
    [SerializeField] private List<string> nameItem = new List<string>();

    [SerializeField] private List<TextMeshProUGUI> txtItems = new List<TextMeshProUGUI>();
    [SerializeField] private string texte;

    private int minumumForFinish;

    private void Awake()
    {
        minumumForFinish = Items.Count -2;
        print(minumumForFinish);
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
        print("Change bool");
        Items[index] = true;
        txtItems[index].color = Color.red;
    }

    void VerifyIfAllBool()
    {
        for (int i = 0; i < Items.Count; i++)
        {
        }
    }
}
