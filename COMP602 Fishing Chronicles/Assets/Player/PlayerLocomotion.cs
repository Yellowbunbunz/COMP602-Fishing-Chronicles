using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    InputManager inputManager;    //calls C# script input manager to use it's functions

    Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody playerRigidbody;

    public float movementSpeed = 7f;
    public float rotationSpeed = 15f;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
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
        moveDirection = moveDirection * movementSpeed;

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
}
