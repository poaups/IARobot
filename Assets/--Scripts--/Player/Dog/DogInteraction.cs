using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DogInteraction : MonoBehaviour
{
    [System.Flags]
    public enum DogBehaviors
    {
        None = 0,          // Aucun comportement sélectionné
        Impulsion = 1 << 0,
        Vision = 1 << 1,
        Overloading = 1 << 2
    }
    public DogBehaviors currentBehaviors;

    [SerializeField] private GameObject _trigger;

    private TriggerVision _triggerVision;
    private bool _endActiviy = false;
    [HideInInspector] public bool _canImpulse = false;
    [SerializeField] private Machine _machine;


    private void Awake()
    {
        _triggerVision = GetComponentInChildren<TriggerVision>();
    }

    void Update()
    {
        ImpulstionFct();
        VisionFct();
        OverloadingFct();
    }

    void ImpulstionFct()
    {
        if (Input.GetKeyDown(KeyCode.E) && (currentBehaviors & DogBehaviors.Impulsion) != 0)
        {
            _canImpulse = true;
        }

        if(Input.GetKeyUp(KeyCode.E))
        {
            InverseImpulse();
        }
    }

    public void InverseImpulse()
    {
        _canImpulse =! _canImpulse;
    }
    void VisionFct()
    {
        if (Input.GetKeyDown(KeyCode.R) && (currentBehaviors & DogBehaviors.Vision) != 0 && !Gamemanager.instance.IsFading)
        {
            StartCoroutine(Gamemanager.instance.FadeIn());
            
            if(_triggerVision._goDetected.Count >= 1)
            {
                foreach (GameObject _goHasBeenDetected in _triggerVision._goDetected)
                {
                    _goHasBeenDetected.gameObject.GetComponent<CanVision>().AbleFoot();
                }
            }
        }
     

    }

    void OverloadingFct()
    {
        if (Input.GetKeyDown(KeyCode.F) && (currentBehaviors & DogBehaviors.Overloading) != 0 && !_endActiviy)
        {
            _endActiviy = true; // ca va marcher que sur une activité 
            _machine.OverLoadingMachine();
        }
    }

    public void ResetBehaviors()
    {
        currentBehaviors = DogBehaviors.None;
    }

    // Coroutine pour désactiver le trigger après 1 frame
    private IEnumerator DisableTriggerAfterOneFrame()
    {
        print("couroutine");
        yield return null;
        _trigger.SetActive(false);
    }
}
