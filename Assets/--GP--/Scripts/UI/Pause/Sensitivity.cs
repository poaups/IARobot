//using TMPro;
//using UnityEngine;
//using UnityEngine.UI;

//public class Sensitivity : MonoBehaviour
//{
//    public float valueMouse;
//    [SerializeField] private TextMeshProUGUI txtSensitivity;
//    //[SerializeField] private TPSCameraController camera;
    
//    private Slider slider;

//    private void Awake()
//    {
//        slider = GetComponent<Slider>();
//    }
//    private void Update()
//    {
//        txtSensitivity.text = slider.value.ToString();
//        valueMouse = slider.value;

//        //camera.SetSensitivity(slider.value);
//    }

//    public void SetSlider(float newValue)
//    {
//        slider.value = newValue;
//    }
//}
