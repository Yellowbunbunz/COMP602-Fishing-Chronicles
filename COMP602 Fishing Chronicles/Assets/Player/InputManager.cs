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
    
    //for speed control
    public bool sprint_Input;
    public bool walking_Input;
    public bool jump_Input;
    //for jump
    public float verticalInput;
    public float horizontalInput;

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

            //player Speed
            playerControls.PlayerActions.Walking.performed += i => walking_Input = true;
            playerControls.PlayerActions.Walking.canceled += i => walking_Input = false;
            playerControls.PlayerActions.Sprint.performed += i => sprint_Input = true;
            playerControls.PlayerActions.Sprint.canceled += i => sprint_Input = false;

            //player jump
            playerControls.PlayerActions.Jump.performed += i => jump_Input = true;
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
        animtionManager.UpdateAnimatorValues(0, moveAmount, playerLocomotion.isSprinting, playerLocomotion.isWalking);
    }

    private void HandleSpeedControl()
    {
        if(sprint_Input && moveAmount > 0.5f)
        {
            playerLocomotion.isSprinting = true;
        }
        else if (walking_Input)
        {
            playerLocomotion.isWalking = true;
        }
        else
        {
            playerLocomotion.isSprinting = false;
            playerLocomotion.isWalking = false;
        }
    }

    private void HandleJumpingInput()
    {
        if(jump_Input)
        {
            jump_Input = false;
            playerLocomotion.HandleJumping();
        }
    }

    //calls all movementinputs
    public void HandleAllInputs()
    {
        //Basically just call all functions inside this script
        HandleMovementInput();
        HandleSpeedControl();
        HandleJumpingInput();
    }
}
