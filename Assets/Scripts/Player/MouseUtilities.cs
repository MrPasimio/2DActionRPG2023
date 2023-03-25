using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//L7
using UnityEngine.InputSystem;


public class MouseUtilities : MonoBehaviour
{
    //L7 - Make the player face the direction of the mouse

    //L7 - variables
    private Camera cam;


    //L7 set the main camera
    private void Awake()
    {
        cam = Camera.main;
    }

    //L7 - get the direction of the mouse
    public Vector2 GetMouseDirection(Vector2 origin)
    {
        //Screen position (in pixels) of the mouse
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        //Convert screen position to world position
        Vector2 mouseWorldPos = cam.ScreenToWorldPoint(mouseScreenPos);

        return mouseWorldPos - origin;
    }
}
