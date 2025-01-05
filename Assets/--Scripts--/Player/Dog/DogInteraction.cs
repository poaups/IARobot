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
    [HideInInspector] public bool _canOverloading = false;
    [SerializeField] private Machine _machine;
    [SerializeField] private GameObject _panelBreakableUI;
    [SerializeField] private CanBreakable _canBreakable;

    private void Awake()
    {
        _triggerVision = GetComponentInChildren<TriggerVision>();
    }

    void Update()
    {
        print("can impulse" + _canImpulse);
        ImpulstionFct();
        VisionFct();
        OverloadingFct();
    }
    public void ChangeBehavior(DogBehaviors behavior)
    {
        currentBehaviors |= behavior;
    }
    public void DisableBehavior(DogBehaviors behavior)
    {
        currentBehaviors &= ~behavior;
    }

    void ImpulstionFct()
    {
        if (Input.GetKeyDown(KeyCode.E) && (currentBehaviors & DogBehaviors.Impulsion) != 0 && _canBreakable._alreadyBreak == false)
        {
            print("E");
            _panelBreakableUI.SetActive(true);
        }


    }

    public void InverseImpulse()
    {
        print("InverseImpulse");
        _canImpulse = true;
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
        if (Input.GetKeyDown(KeyCode.F) && (currentBehaviors & DogBehaviors.Overloading) != 0 && !_endActiviy && _canOverloading)
        {
            _endActiviy = true;
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
