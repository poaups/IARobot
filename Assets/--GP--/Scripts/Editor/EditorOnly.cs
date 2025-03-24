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
        if (GUILayout.Button("Appliquer Rotation Al�atoire aux Enfants"))
        {
            // Enregistrer les objets s�lectionn�s dans l'historique d'annulation d'Unity
            Undo.RecordObject(target, "Appliquer Rotation Al�atoire aux Enfants");

            // Appliquer la rotation aux enfants du parent
            RandomRotation randomRotation = (RandomRotation)target;
            randomRotation.ApplyRandomRotation();

            // Rafra�chir l'�diteur
            SceneView.RepaintAll();
        }
    }
}