using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sensitivity : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtSensitivity;
    [SerializeField] private TPSCameraController camera;
    
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    private void Update()
    {
        txtSensitivity.text = slider.value.ToString();
        camera.SetSensitivity(slider.value);
    }
}
