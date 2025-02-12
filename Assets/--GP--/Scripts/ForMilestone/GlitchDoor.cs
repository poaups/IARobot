using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GlitchDoor : MonoBehaviour
{
    public List<Material> materials = new List<Material>();
    [Range(0f, 1f)]
    public float TimeBetwenColor;
    public MeshRenderer localMaterial;
    private void Awake()
    {
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        while (true) 
        {
            int mat = Random.Range(0, materials.Count);
            localMaterial.material = materials[mat];

            TimeBetwenColor = Random.Range(0f, 1f); 
            yield return new WaitForSeconds(TimeBetwenColor);
        }
    }

}
