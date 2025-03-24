//using UnityEngine;

//public class CrosshairToWorld : MonoBehaviour
//{
//    [SerializeField] private RectTransform crosshairUI; // Référence vers le crosshair UI
//    [SerializeField] private Camera mainCamera; // La caméra principale
//    [SerializeField] private LayerMask groundLayer; // Le layer sur lequel on veut placer l'objet
//    [SerializeField] private GameObject objectToSpawn; // L'objet à instancier

//    void Update()
//    {
//        if (Input.GetMouseButtonDown(0)) // Exemple : Clique gauche pour créer un objet
//        {
//            PlaceObjectAtCrosshair();
//        }
//    }

//    void PlaceObjectAtCrosshair()
//    {
//        Vector3 screenPosition = crosshairUI.position; // Position écran du crosshair
//        Ray ray = mainCamera.ScreenPointToRay(screenPosition);

//        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundLayer))
//        {
//            Instantiate(objectToSpawn, hit.point, Quaternion.identity);
//        }
//    }
//}
