//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Neck : MonoBehaviour
//{
//    [SerializeField] private GameObject camera;
//    [SerializeField] private float min; // Limite minimale de rotation
//    [SerializeField] private float max; // Limite maximale de rotation

//    private void Update()
//    {
//        // On r�cup�re l'angle Y de la cam�ra
//        float cameraRotationY = camera.transform.eulerAngles.y;

//        // On applique la limite de rotation
//        float clampedRotationY = Mathf.Clamp(cameraRotationY, min, max);

//        // On applique la rotation � la t�te du personnage, en gardant les autres axes constants
//        transform.eulerAngles = new Vector3(transform.eulerAngles.x, clampedRotationY, transform.eulerAngles.z);
//    }
//}
