using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    AnimationManager animtionManager;

    public Vector2 movementInput;
    public Vector2 cameraInput;

    public float cameraInputX;
    public float cameraInputY;

    private float moveAmount;
    //for jump
    public float verticalInput;
    public float horizontalInput;

    public void Awake()
    {
        animtionManager = GetComponent<AnimationManager>();
    }

    private void OnEnable()
    {
        //creates a single instance of playerControls
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            //gets what keys have been pressed and returns -1 or 1 based on what key is pressed.
            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
        }

        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void HandleMovementInput()
    {
        //player movement
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        //Camera movement
        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;

        //Animation
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animtionManager.UpdateAnimatorValues(0, moveAmount);
    }

    //calls all movementinputs
    public void HandleAllInputs()
    {
        HandleMovementInput();
        //later be used to basically be able to call all other HandlexyzInput
    }
}
