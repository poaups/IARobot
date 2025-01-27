using StarterAssets;
using UnityEngine;

public class PManager : MonoBehaviour
{
    public static PManager Instance;

    public StarterAssetsInputs inputPM;

    private void Awake()
    {
        Instance = this;
    }
}
