using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class characterScript : MonoBehaviour
{
    InputAction moveAction;
    InputAction jumpAction;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        //test

        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0;

        if(cameraForward != Vector3.zero){
            cameraForward.Normalize();
        }
        Vector3 moveStep = playerSpeed * Time.deltaTime *
         (moveValue.x * Camera.main.transform.right +
          moveValue.y * cameraForward);

        controller.Move(moveStep);

        
        // Makes the player jump
        if (jumpAction.ReadValue<float>()> 0 && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}