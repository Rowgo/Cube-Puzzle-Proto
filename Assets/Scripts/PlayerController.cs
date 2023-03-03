using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private CharacterMovement _characterMovement;
    private Vector2 _moveInput;

    private void Awake()
    {
        _characterMovement = GetComponent<CharacterMovement>();
    }

    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
        _characterMovement.Move(_moveInput);
    }
}
