using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //make sure after this code is used anywhere, change rigid body's interpolate from none to interpolate
    //otherwise camera will stutter

    InputManager inputManager;

    public const float collision = 0.2f;

    public Transform targetTransform;//object to be followed
    public Transform cameraPivot; //object camera will use to pivot
    public Transform cameraTransform;//camera that follows player
    public LayerMask collisionLayers;//layers we don't want our camera to clip though
    private Vector3 cameraFollowVel = Vector3.zero;
    private float defaultPostion;//spot camera returns to
    private Vector3 cameraVectorPosition;

    public float cameraCollisonOffSet = collision;//how far camera will jump off of collision
    public float minCollisionOffSet = collision;
    public float cameraCollisonRadius = collision;//size of area that the camera will "collide" into objects to stop clipping
    public float lookAngle; //Left and right
    public float pivotAngle; //Up and down

    public float minPivotAngle = -35;//lock bot
    public float maxPivotAngle = 35;//lock top
    public float minLookAngle = -180;//lock left
    public float maxLookAngle = 180;//lock right

    public float cameraFollowSpeed = 0.2f;
    public float cameraLookSpeed = 2f;//how fast it turns up and down
    public float cameraPivotSpeed = 0.5f;//how fast it turns left and right

    private void Awake()
    {
        //can just make objects that need to be found
        //type public and drag and drop wanted input manager into it
        inputManager = FindObjectOfType<InputManager>();
        targetTransform = FindObjectOfType<PlayerManager>().transform;
        cameraTransform = Camera.main.transform;
        defaultPostion = cameraTransform.localPosition.z;
    }

    private void FollowPlayer()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVel, cameraFollowSpeed);
        transform.position = targetPosition;
    }

    private void RotateCamera()
    {
        Vector3 rotation;
        Quaternion targetRoation;

        lookAngle = lookAngle + (inputManager.cameraInputX * cameraLookSpeed);
        pivotAngle = pivotAngle - (inputManager.cameraInputY * cameraPivotSpeed);

        //locking to prevent infinte turns
//        lookAngle = Mathf.Clamp(lookAngle, minLookAngle, maxLookAngle);
        pivotAngle = Mathf.Clamp(pivotAngle, minPivotAngle, maxPivotAngle);


        //left right control
        rotation = Vector3.zero;
        rotation.y = lookAngle;
        //please don't ask me what Euler means I just followed the guide
        targetRoation = Quaternion.Euler(rotation);
        transform.rotation = targetRoation;

        //up down control
        rotation = Vector3.zero;
        rotation.x = pivotAngle;
        targetRoation = Quaternion.Euler(rotation);
        cameraPivot.localRotation = targetRoation;
    }

    private void HandleCameraCollisions()
    {
        float targetPosition = defaultPostion;
        RaycastHit hit;//gives us info on what we hit

        Vector3 direction = cameraTransform.position - cameraPivot.position;
        direction.Normalize();

        
        if(Physics.SphereCast(cameraPivot.transform.position, cameraCollisonRadius, direction, out hit, Mathf.Abs(targetPosition), collisionLayers))//creates an invisible sphere around object
        {
            float distance = Vector3.Distance(cameraPivot.position, hit.point);
            targetPosition = -(distance - cameraCollisonOffSet);
        }

        if(Mathf.Abs(targetPosition) < minCollisionOffSet)
        {
            targetPosition = targetPosition - minCollisionOffSet;
        }

        cameraVectorPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, collision);
        cameraTransform.localPosition = cameraVectorPosition;
    }

    public void HandleAllCameraMovement()
    {
        FollowPlayer();
        RotateCamera();
        HandleCameraCollisions();
    }
}
