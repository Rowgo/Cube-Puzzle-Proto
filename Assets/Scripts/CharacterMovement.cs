using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 0.5f;
    [SerializeField] LayerMask _gridLayer; //Could be done better through grabbing a reference to the layer that the grid is on.
    private Collider _collider;
    private bool _rotating;
    private MeshRenderer _meshRenderer;

    private Vector3 _extents => _collider.bounds.extents;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Move(Vector2 Direction)
    {
        if (_rotating == true) return;
        _rotating = true;
        Direction.Normalize();
        Vector3 newPosition = new Vector3(Direction.x, 0, Direction.y);
        //_character.transform.position += newPosition;

        Vector3 rotationAxis = Vector3.Cross(newPosition, Vector3.up).normalized;
        
        Vector3 cubeCorner = new Vector3(Direction.x * _extents.x, -_extents.y, Direction.y * _extents.z);
        Vector3 rotateAround = _collider.bounds.center + cubeCorner;

        StartCoroutine(RotateCube(rotationAxis, rotateAround));
    }

    private IEnumerator RotateCube(Vector3 axis, Vector3 corner)
    {
        //float elapsedTime = 0f;
        float totalRotation = 0;
        while(_rotating == true)
        {
            // shitty method
            float spinAmount = Mathf.Min(Time.deltaTime * _rotationSpeed, 90f - totalRotation);

            // lerp method to ensure there aren't any floating values after the rotation of the object is finished. ( not shitty method )
            // curretnly using a lerp for rotate around adds the value over time and causes the object to spin multiple times instead
            // of just 90 degrees since rotate around is simply asking for an angle to add to the object's rotation each frame.
            //elapsedTime += Time.deltaTime;
            //float percentageTime = elapsedTime / _rotationSpeed;
            //percentageTime = Mathf.Clamp(percentageTime, 0f, 1f);
            //float spin = Mathf.Lerp(0f, 90f, percentageTime);

            transform.RotateAround(corner, axis, -spinAmount);

            totalRotation += spinAmount;

            if (totalRotation == 90f)
            {
                ChangeBlockColor();
                

                _rotating = false;
            }
            yield return null;
        }

    }

    private void ChangeBlockColor()
    {
        RaycastHit hit;

        Physics.Raycast(_collider.bounds.center, Vector3.down, out hit, 10, _gridLayer);
        Debug.DrawRay(_collider.bounds.center, Vector3.down, Color.red, 10f);

        if( hit.transform.gameObject.TryGetComponent<GridBlock>(out GridBlock gridBlock))
        {
            gridBlock.ChangeColor(_meshRenderer);
        }
        
    }
}
