using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class CubeColor : MonoBehaviour
{
    public Color _meshColor = Color.white;

    private Material _instanceMaterial;

    void Update()
    {
        Renderer cubeRenderer = GetComponent<Renderer>();
        if (cubeRenderer != null)
        {
            if (_instanceMaterial == null)
            {
                _instanceMaterial = new Material(cubeRenderer.sharedMaterial);
                cubeRenderer.sharedMaterial = _instanceMaterial;
            }

            _instanceMaterial.color = _meshColor;
        }
    }

    void OnDestroy()
    {
        if (_instanceMaterial != null)
        {
            DestroyImmediate(_instanceMaterial);
        }
    }
}

