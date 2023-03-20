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

    private Vector2 moveInput;

    private void FixedUpdate()
    {
        Vector2 velocity = moveInput * moveSpeed;
        rig.velocity = velocity;
    }
}
