using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeBlock : GridBlock
{
    public override void ChangeColor(MeshRenderer meshRenderer)
    {
        meshRenderer.material = _meshRenderer.material;
    }
}
