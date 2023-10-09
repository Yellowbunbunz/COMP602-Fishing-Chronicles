using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    PlayerLocomotion playerLocomotion;
    public Animator animator;

    public int horizontal;
    public int vertical;
    public float snappedHorizontal;
    public float snappedVertical;
    private void Awake()
    {
        playerLocomotion = GetComponent<PlayerLocomotion>();
        animator = GetComponent<Animator>();
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
    }

    public void PlayTargetAnimation(string targetAnimation, bool isInteracting)
    {
        animator.SetBool("isInteracting", isInteracting);
        animator.CrossFade(targetAnimation, 0.2f);//changes to targeted animation
    }

    public void UpdateAnimatorValues(float horizontalMovement, float verticalMovement)
    {
        //animationSnapping


        #region Snapped Horizontal
        if (horizontalMovement > 0 && horizontalMovement < 0.55f)
        {
            Debug.Log("walking");
            snappedHorizontal = 0.5f;
        }
        else if(horizontalMovement > 0.55f)
        {
            Debug.Log("running");
            snappedHorizontal = 1;
        }
        else if (horizontalMovement < 0 && horizontalMovement > -0.55f)
        {
            snappedHorizontal = -0.5f;
        }
        else if (horizontalMovement < -0.55f)
        {
            snappedHorizontal = -1;
        }
        else
        {
            snappedHorizontal = 0;
        }
        #endregion
        #region Snapped Vertical
        if (verticalMovement > 0 && verticalMovement < 0.55f)
        {
            Debug.Log("walking 2");
            snappedVertical = 0.5f;
        }
        else if (verticalMovement > 0.55f)
        {
            Debug.Log("running");
            snappedVertical = 1;
        }
        else if (verticalMovement < 0 && verticalMovement > -0.55f)
        {
            snappedVertical = -0.5f;
        }
        else if (verticalMovement < -0.55f)
        {
            snappedVertical = -1;
        }
        else
        {
            snappedVertical = 0;
        }
        #endregion

        if(playerLocomotion.isSprinting)
        {
            snappedVertical = 2;
        }
        else if(playerLocomotion.isWalking)
        {
            snappedVertical = 0.5f;
        }

        animator.SetFloat(horizontal, snappedHorizontal, 0.1f, Time.deltaTime);
        animator.SetFloat(vertical, snappedVertical, 0.1f, Time.deltaTime);
    }
}
