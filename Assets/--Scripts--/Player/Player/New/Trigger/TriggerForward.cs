using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForward : MonoBehaviour
{
    private GameObject goStocked = null;

    // Lorsqu'un autre collider entre dans la zone de d�clenchement
    private void OnTriggerEnter(Collider other)
    {
        // V�rifier si l'objet a un composant Shelf
        if (other.GetComponent<Shelf>() != null)
        {
            goStocked = other.gameObject;
            Debug.Log("Objet d�tect� : " + goStocked.name);
        }
    }

    // Lorsqu'un autre collider sort de la zone de d�clenchement
    private void OnTriggerExit(Collider other)
    {
        // V�rifier si l'objet qui sort est celui qui �tait stock�
        if (goStocked != null && goStocked == other.gameObject)
        {
            Debug.Log("Objet sortant : " + goStocked.name);
            goStocked = null;
        }
    }

    // V�rification dans Update si un objet est stock�
    private void Update()
    {
        // V�rifier si goStocked est non nul avant d'y acc�der
        if (goStocked != null)
        {
            print(goStocked.name + " est actuellement stock�");
        }
        else
        {
            print("Aucun objet stock�");
        }
    }
}
