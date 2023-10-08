using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    PlayerManager playerManager;
    InputManager inputManager;    //calls C# script input manager to use it's functions
    AnimationManager animationManager;

    Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody playerRigidbody;

    [Header("Falling")]
    public float inAirTimer;
    public float leapingVelocity;
    public float fallingVelocity;
    public float rayCastHeightOffSet = 0.5f;
    public LayerMask groundLayer;

    [Header("Movement Flags")]
    public bool isSprinting;
    public bool isWalking;
    public bool isGrounded;
    public bool isJumping;

    [Header("Moving Speeds")]
    public float walkingSpeed = 1f;
    public float runningSpeed = 2f;
    public float sprintSpeed = 5f;
    public float rotationSpeed = 15f;

    [Header("Jumping")]
    public float jumpHeight = 3;
    public float gravityIntensity = -15;

    private void Awake()
    {
        animationManager = GetComponent<AnimationManager>();
        playerManager = GetComponent<PlayerManager>();
        inputManager = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    //moves player but will keep straight
    private void HandleMovement()
    {
        if (isJumping)
            return;

        //sees what direction camera is facing and moves player based on that
        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right * inputManager.horizontalInput;
        //takes our direction, and keeps it the same but changes the length to 1 to keep it consistent
        moveDirection.Normalize();
        //stops you flying
        moveDirection.y = 0;

        if(isSprinting)
        {
            moveDirection = moveDirection * sprintSpeed;
        }
        else if(isWalking)
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
        if (isJumping)
            return;

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

        if(!isGrounded && !isJumping)
        {
            //changes you to the falling animation
            if(!playerManager.isInteracting)
            {
                animationManager.PlayTargetAnimation("Falling", true);
            }
            //everything here controls the dropping speed everything else deals with animation
            inAirTimer = inAirTimer + Time.deltaTime;
            playerRigidbody.AddForce(transform.forward * leapingVelocity);
            playerRigidbody.AddForce(-Vector3.up * fallingVelocity * inAirTimer);
        }

        //changes you to the landing animation
        if(Physics.SphereCast(rayCastOrigin, 0.2f, -Vector3.up, out hit, groundLayer))
        {
            if (!isGrounded && !playerManager.isInteracting)
            {
                animationManager.PlayTargetAnimation("Land", true);
            }

            inAirTimer = 0;
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    public void HandleJumping()
    {
        if(isGrounded)
        {
            animationManager.animator.SetBool("isJumping", true);
            animationManager.PlayTargetAnimation("Jump", false);

            float jumpingVel = Mathf.Sqrt(-2 * gravityIntensity * jumpHeight);
            Vector3 playerVel = moveDirection;
            playerVel.y = jumpingVel;
            playerRigidbody.velocity = playerVel;
        }
    }

    public void HandleAllMovement()
    {
        HandleFallingAndLanding();

        if (playerManager.isInteracting)
            return;

        if (isJumping)
            return;

        HandleMovement();
        HandleRotation();
    }
}
