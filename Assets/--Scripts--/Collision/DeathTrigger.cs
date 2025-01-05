using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _deathImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other != null && other.gameObject.GetComponent<PlayerLocomotion>() != null)
        {
            _deathImage.SetActive(true);
        }
    }
}
