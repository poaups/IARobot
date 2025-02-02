using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private int numberCounter;
    [SerializeField] private string textBeforeValue;

    private TextMeshProUGUI textCounter;

    private void Awake()
    {
        textCounter = GetComponent<TextMeshProUGUI>();
        textCounter.text = textBeforeValue + numberCounter;
    }
    public void AddValue(int addToValue)
    {
        print("AddValue");
        numberCounter -= addToValue;
        textCounter.text = textBeforeValue + numberCounter;
    }
}
