using UnityEngine;

/// <summary>
/// Setup the ladder for clim into the bus after being pick
/// </summary>
public class SetupLadderBus : MonoBehaviour, IInteraction
{
    [SerializeField] private GameObject prefabLadderClim;
    public void OnInteract()
    {
        if(prefabLadderClim != null)
        {
            prefabLadderClim.SetActive(true);
        }
    }
}
