//using UnityEngine;

//public class CrosshairToWorld : MonoBehaviour
//{
//    [SerializeField] private RectTransform crosshairUI; // R�f�rence vers le crosshair UI
//    [SerializeField] private Camera mainCamera; // La cam�ra principale
//    [SerializeField] private LayerMask groundLayer; // Le layer sur lequel on veut placer l'objet
//    [SerializeField] private GameObject objectToSpawn; // L'objet � instancier

//    void Update()
//    {
//        if (Input.GetMouseButtonDown(0)) // Exemple : Clique gauche pour cr�er un objet
//        {
//            PlaceObjectAtCrosshair();
//        }
//    }

//    void PlaceObjectAtCrosshair()
//    {
//        Vector3 screenPosition = crosshairUI.position; // Position �cran du crosshair
//        Ray ray = mainCamera.ScreenPointToRay(screenPosition);

//        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundLayer))
//        {
//            Instantiate(objectToSpawn, hit.point, Quaternion.identity);
//        }
//    }
//}
