using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public float FinalSensi;

    [SerializeField] private Sensitivity mouseSettings;
    [SerializeField] private GameObject OptionMenu;
    [SerializeField] private Slider slider;


    private void Awake()
    {
        DontDestroyOnLoad(this);
        if(slider != null)
        {
            print("Pas null settings");
            FinalSensi = slider.value;
        }
        else
        {
            print("Null slider dans Settings");
            slider = GameObject.FindAnyObjectByType(typeof(Slider)) as Slider;
            if(slider != null )
            {
                print("Slider retrouve n'est pas null");
            }
            else
            {
                print("Encore null");
            }
        }
      

        if(OptionMenu != null )
        {
            OptionMenu.SetActive(false);
        }
    }
}
