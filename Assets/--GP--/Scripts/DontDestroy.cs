using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    [SerializeField] private Sensitivity mouseSettings;
    //[SerializeField] private TPSCameraController camera;
    public float value;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        value = mouseSettings.valueMouse;
        //camera.SetSensitivity(value);
    }
}
