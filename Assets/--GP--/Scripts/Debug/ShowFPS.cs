using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFPS : MonoBehaviour
{
    private float deltaTime = 0.0f;

    void Update()
    {
        // Calculer le temps écoulé entre les images
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        // Calcul des FPS
        float fps = 1.0f / deltaTime;
        string fpsText = $"{fps:0.} FPS";

        // Style d'affichage
        GUIStyle style = new GUIStyle();
        style.fontSize = 24;
        if (fps > 55)
        {
            style.normal.textColor = Color.white;
        }
        else 
        {
            style.normal.textColor = Color.red;
        }

        // Afficher les FPS à l'écran
        GUI.Label(new Rect(10, 10, 200, 50), fpsText, style);
    }
}
