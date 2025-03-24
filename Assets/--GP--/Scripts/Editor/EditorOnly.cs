using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RandomRotation))]
public class RandomRotationEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Affiche l'inspecteur standard pour le script RandomRotation
        DrawDefaultInspector();

        // Ajouter un bouton dans l'inspecteur
        if (GUILayout.Button("Appliquer Rotation Aléatoire aux Enfants"))
        {
            // Enregistrer les objets sélectionnés dans l'historique d'annulation d'Unity
            Undo.RecordObject(target, "Appliquer Rotation Aléatoire aux Enfants");

            // Appliquer la rotation aux enfants du parent
            RandomRotation randomRotation = (RandomRotation)target;
            randomRotation.ApplyRandomRotation();

            // Rafraîchir l'éditeur
            SceneView.RepaintAll();
        }
    }
}