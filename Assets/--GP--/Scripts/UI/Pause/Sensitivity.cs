using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sensitivity : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtSensitivity;
    [SerializeField] private Settings settings;
    [SerializeField] private TPSCameraController camera;
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        txtSensitivity.text = slider.value.ToString();
    }
    public void OnChange()
    {
        SetSlider(slider.value);

    }
    public void SetSlider(float newValue)
    {
        slider.value = newValue;
        txtSensitivity.text = slider.value.ToString();

        if (settings != null)
        {
            settings.FinalSensi = slider.value;
        }

        if (camera != null)
        {
            camera.SetSensitivity(slider.value);
        }
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.O))
        {
            AbleSettings();
        }
    }
    //Between menu and maingame, settings need to be refind and set the value save in menu
    public void AbleSettings()
    {
        //print("AbleSettings");
        settings = GameObject.FindAnyObjectByType<Settings>();
        if(settings != null)
        {
            SetSlider(settings.FinalSensi);
        }
   
    }
}
