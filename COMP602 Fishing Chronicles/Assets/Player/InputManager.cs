using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    public Vector2 movementInput;
    //for jump
    public float verticalInput;
    public float horizontalInput;

    private void OnEnable()
    {
        //creates a single instance of playerControls
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            //gets what keys have been pressed and returns -1 or 1 based on what key is pressed.
            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
        }

        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
    }

    //calls all movementinputs
    public void HandleAllInputs()
    {
        HandleMovementInput();
        //later be used to basically be able to call all other HandlexyzInput
    }
}
