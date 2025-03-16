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
//        // On récupère l'angle Y de la caméra
//        float cameraRotationY = camera.transform.eulerAngles.y;

//        // On applique la limite de rotation
//        float clampedRotationY = Mathf.Clamp(cameraRotationY, min, max);

//        // On applique la rotation à la tête du personnage, en gardant les autres axes constants
//        transform.eulerAngles = new Vector3(transform.eulerAngles.x, clampedRotationY, transform.eulerAngles.z);
//    }
//}
