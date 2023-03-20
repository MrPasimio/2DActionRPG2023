using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playercr : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [Header("Components")]
    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private MouseControl mouseUtilities;

    private Vector2 moveInput;

    private void Update()
    {
        Vector2 mouseDirection = mouseUtilities.GetMouseDirection(transform.position);

        sr.flipX = mouseDirection.x < 0;
    }

    private void FixedUpdate()
    {
        Vector2 velocity = moveInput * moveSpeed;
        rig.velocity = velocity;
    }

    public void OnMoveInput (InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
