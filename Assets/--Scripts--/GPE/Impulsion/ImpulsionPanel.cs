using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImpulsionPanel : MonoBehaviour
{
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;
    [SerializeField] private float _speedGauge;
    [SerializeField] private List<Image> _allImage;
    
    private DogInteraction _dogInteraction;

    private int test = 0;

    void Start()
    {
        _dogInteraction = Gamemanager.instance._dogInteractionGM;
        this.transform.position = _start.position;
    }

    void Update()
    {
        if(test == 2)
        {
            return;
        }

        else if (test == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, _end.position, _speedGauge * Time.deltaTime);

            if (Vector3.Distance(transform.position, _end.position) < 0.01f) // Vérification basée sur la distance
            {
                test = 1;
            }
        }
        else 
        {
            transform.position = Vector3.MoveTowards(transform.position, _start.position, _speedGauge * Time.deltaTime);

            if (Vector3.Distance(transform.position, _start.position) < 0.01f) // Vérification basée sur la distance
            {
                test = 0;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other != null && Input.GetMouseButtonDown(0))
        {
            test = 2;
            other.gameObject.GetComponent<Image>().color = Color.green;
            _dogInteraction._canImpulse = true;
            //LowerAlpha();
        }
    }

    void LowerAlpha()
    {
        if (_allImage == null || _allImage.Count == 0)
        {
            Debug.LogWarning("The _allImage list is empty or not assigned.");
            return;
        }

        foreach (Image image in _allImage)
        {
            if (image != null)
            {
                Color color = image.color;
                color.a = 100f / 255f;
                image.color = color;
            }
            else
            {
                Debug.LogWarning("One of the images in the _allImage list is null.");
            }
        }
    }
}
