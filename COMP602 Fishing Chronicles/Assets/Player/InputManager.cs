using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    AnimationManager animtionManager;
    PlayerLocomotion playerLocomotion;

    public Vector2 movementInput;
    public Vector2 cameraInput;

    public float cameraInputX;
    public float cameraInputY;

    public float moveAmount;
    //for jump
    public float verticalInput;
    public float horizontalInput;

    public bool shift_Input;
    public bool ctrl_Input;

    public void Awake()
    {
        animtionManager = GetComponent<AnimationManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
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

            //speed control
            playerControls.PlayerActions.Sprinting.performed += i => shift_Input = true;
            playerControls.PlayerActions.Sprinting.canceled += i => shift_Input = false;
            playerControls.PlayerActions.Walking.performed += i => ctrl_Input = true;
            playerControls.PlayerActions.Walking.canceled += i => ctrl_Input = false;
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

    private void HandleSpeedInput()
    {
        if(shift_Input && moveAmount > 0.5f)
        {
            playerLocomotion.isSprinting = true;
            playerLocomotion.isWalking = false;
        }
        else if(ctrl_Input)
        {
            playerLocomotion.isSprinting = false;
            playerLocomotion.isWalking = true;
        }
        else
        {
            playerLocomotion.isSprinting = false;
            playerLocomotion.isWalking = false;
        }
    }

    //calls all movementinputs
    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleSpeedInput();
        //later be used to basically be able to call all other HandlexyzInput
    }
}
