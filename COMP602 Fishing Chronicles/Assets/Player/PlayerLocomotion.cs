using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    PlayerManager playerManager;
    AnimationManager animatorManager;
    InputManager inputManager;    //calls C# script input manager to use it's functions

    Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody playerRigidbody;

    [Header("Movement Flags")]
    public bool isSprinting;
    public bool isWalking;
    public bool isGrounded;

    [Header("Falling")]
    public float inAirTimer;
    public float leapingVel = 100;
    public float fallingVel = 33;
    public float rayCastHeightOffSet = 0.5f;
    public LayerMask groundLayer;

    [Header("Movement Speeds")]
    public float walkingSpeed = 1.5f;
    public float runningSpeed = 7f;
    public float sprintingSpeed = 15f;
    public float rotationSpeed = 15f;

    private void Awake()
    {
        animatorManager = GetComponent<AnimationManager>();
        playerManager = GetComponent<PlayerManager>();
        inputManager = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    //moves player but will keep straight
    private void HandleMovement()
    {
        //sees what direction camera is facing and moves player based on that
        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput;
        //takes our direction, and keeps it the same but changes the length to 1 to keep it consistent
        moveDirection.Normalize();
        //stops you flying
        moveDirection.y = 0;

        if(isSprinting)
        {
            moveDirection = moveDirection * sprintingSpeed;
        }
        if (isWalking)
        {
            moveDirection = moveDirection * walkingSpeed;
        }
        else
        {
            moveDirection = moveDirection * runningSpeed;
        }

        Vector3 movementVelocity = moveDirection;
        //this should move the player
        playerRigidbody.velocity = movementVelocity;
    }

    //moves direction player is facing
    private void HandleRotation()
    {
        //the direction the player will be facing and sets everything to 0 as script is called
        Vector3 targetDirecton = Vector3.zero;

        targetDirecton = cameraObject.forward * inputManager.verticalInput;
        targetDirecton = targetDirecton + cameraObject.right * inputManager.horizontalInput;
        targetDirecton.Normalize();
        targetDirecton.y = 0;

        //keeps player facing direction they were when they stop moving
        if(targetDirecton == Vector3.zero)
        {
            targetDirecton = transform.forward;
        }

        //Quaternion calculates rotations in unity
        //first rotates camera(I believe) to where you want to look
        Quaternion targetRotation = Quaternion.LookRotation(targetDirecton);
        //rotates player
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }

    private void HandleFallingAndLanding()
    {
        RaycastHit hit;
        Vector3 rayCastOrigin = transform.position;
        rayCastOrigin.y = rayCastOrigin.y + rayCastHeightOffSet;

        if(!isGrounded)
        {
            if(!playerManager.isInteracting)
            {
                animatorManager.PlayTargetAnimation("Falling", true);
            }

            inAirTimer = inAirTimer + Time.deltaTime;
            playerRigidbody.AddForce(transform.forward * leapingVel);
            playerRigidbody.AddForce(-Vector3.up * fallingVel * inAirTimer);//this makes you drop
        }

        if(Physics.SphereCast(rayCastOrigin, 0.2f, -Vector3.up, out hit, groundLayer))
        {
            if(!isGrounded && !playerManager.isInteracting)
            {
                animatorManager.PlayTargetAnimation("Land", true);
            }

            inAirTimer = 0;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    public void HandleAllMovement()
    {
        HandleFallingAndLanding();//reason this is on top is no matter what happens we want the player to fall

        if (playerManager.isInteracting)
            return;

        HandleMovement();
        HandleRotation();
    }
}
