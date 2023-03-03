using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 20f;
    void Update()
    {
        transform.RotateAround(Vector3.right, Vector3.up, _rotationSpeed * Time.deltaTime);
    }
}
