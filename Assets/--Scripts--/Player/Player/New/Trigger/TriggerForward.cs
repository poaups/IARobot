using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForward : MonoBehaviour
{
    private GameObject goStocked = null;

    // Lorsqu'un autre collider entre dans la zone de déclenchement
    private void OnTriggerEnter(Collider other)
    {
        // Vérifier si l'objet a un composant Shelf
        if (other.GetComponent<Shelf>() != null)
        {
            goStocked = other.gameObject;
            Debug.Log("Objet détecté : " + goStocked.name);
        }
    }

    // Lorsqu'un autre collider sort de la zone de déclenchement
    private void OnTriggerExit(Collider other)
    {
        // Vérifier si l'objet qui sort est celui qui était stocké
        if (goStocked != null && goStocked == other.gameObject)
        {
            Debug.Log("Objet sortant : " + goStocked.name);
            goStocked = null;
        }
    }

    // Vérification dans Update si un objet est stocké
    private void Update()
    {
        // Vérifier si goStocked est non nul avant d'y accéder
        if (goStocked != null)
        {
            print(goStocked.name + " est actuellement stocké");
        }
        else
        {
            print("Aucun objet stocké");
        }
    }
}
