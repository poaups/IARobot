using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    public float fixRotation = -90;

    public void ApplyRandomRotation()
    {
        foreach (Transform child in transform)
        {
            // Générer une rotation aléatoire autour de l'axe Z pour chaque enfant
            float randomZ = Random.Range(0f, 360f);
            child.rotation = Quaternion.Euler(fixRotation, 0, randomZ);
        }
    }
}