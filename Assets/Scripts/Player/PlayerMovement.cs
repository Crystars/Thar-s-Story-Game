using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    CharacterController2D characterController;
    [SerializeField]
    float moveSpeed = 0.5f;
    float horizontalMove;
    bool isJump;

    PlayerAnimator playerAnimator;

    private void Start()
    {
        horizontalMove = 0f;
        isJump = false;
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            isJump = true;
        }
    }

    private void FixedUpdate()
    {
        characterController.Move(horizontalMove, false, isJump);
        playerAnimator.Move(horizontalMove);
        //playerAnimator.Jump(isJump);
        isJump = false;
        
       
    }
}
