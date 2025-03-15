using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GameObject GoToThrow;
    public float throwForce = 10f; // Force de propulsion
    public float upwardForce = 3f; // Force vers le haut

    public void Throw()
    {
        if (GoToThrow != null)
        {
            // V�rifie si l'objet a un Rigidbody, sinon en ajoute un
            Rigidbody rb = GoToThrow.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = GoToThrow.AddComponent<Rigidbody>();
            }

            // R�initialise la vitesse au cas o� l'objet �tait d�j� en mouvement
            rb.velocity = Vector3.zero;

            // Applique une force vers l'avant et l�g�rement vers le haut
            Vector3 throwDirection = transform.forward * throwForce + transform.up * upwardForce;
            rb.AddForce(throwDirection, ForceMode.Impulse);

            print("Throw");
        }
    }
}
