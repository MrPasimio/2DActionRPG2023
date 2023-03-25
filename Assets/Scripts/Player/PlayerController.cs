using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lesson 6 - Add InputSystem Library
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //L6 - Adding variables
    [SerializeField] private float moveSpeed;

    [Header("Components")] //Organizational header

    [SerializeField] private Rigidbody2D rig;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private MouseUtilities mouseUtilities; //L7 - connect the mouseUtilities script


    private Vector2 moveInput;

    //L6 - Physics based update method
    private void FixedUpdate()
    {
        //L6 - change the velocity of the player including moveSpeed
        Vector2 velocity = moveInput * moveSpeed;
        rig.velocity = velocity; 
    }

    //Lesson 7 - write a method that will read input
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }


    private void Update()
    {
        //L7 find the direction of the mouse
        Vector2 mouseDirection = mouseUtilities.GetMouseDirection(transform.position);

        //L7 - if the mouse is on the left of the player, flip the sprite.
        spriteRenderer.flipX = mouseDirection.x < 0;
    }


}
