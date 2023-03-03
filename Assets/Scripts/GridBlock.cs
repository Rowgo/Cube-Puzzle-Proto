using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshRenderer))]
public class GridBlock : MonoBehaviour
{
    protected MeshRenderer _meshRenderer;
    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public virtual void ChangeColor(MeshRenderer meshRenderer)
    {
        _meshRenderer.material = meshRenderer.material;
    }
}
