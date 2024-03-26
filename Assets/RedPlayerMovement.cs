using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class RedPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Vector2 movementInput;
    public string team = "Red"; // Add a team variable for the Red player

    // Reference to the Input Action Asset
    public InputActionAsset inputActionAsset;

    // Reference to the Input Action Map
    private InputActionMap playerControlsMap;

    // Reference to the AiController
    private AiController aiController;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerControlsMap = inputActionAsset.FindActionMap("RedPlayerControls");
        aiController = GetComponent<AiController>(); // Get reference to AiController
    }

    private void OnEnable()
    {
        if (playerControlsMap != null)
        {
            // Enable the input action map
            playerControlsMap.Enable();

            // Subscribe to the "Move" action
            playerControlsMap["Move"].started += OnMoveStarted;
            playerControlsMap["Move"].performed += OnMovePerformed;
            playerControlsMap["Move"].canceled += OnMoveCanceled;
        }
    }

    private void OnDisable()
    {
        if (playerControlsMap != null)
        {
            // Unsubscribe from the "Move" action
            playerControlsMap["Move"].started -= OnMoveStarted;
            playerControlsMap["Move"].performed -= OnMovePerformed;
            playerControlsMap["Move"].canceled -= OnMoveCanceled;
        }
    }

    private void FixedUpdate()
    {
        //if (aiController.enabled) // Only move if AiController is enabled
        //{
            // Apply movement based on input
            Vector3 movement = new Vector3(movementInput.x, 0f, movementInput.y) * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + movement);
        //}
    }

    private void OnMoveStarted(InputAction.CallbackContext context)
    {
        // Movement action started
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        // Movement action performed
        movementInput = context.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        // Movement action canceled
        movementInput = Vector2.zero; // Stop movement when action is canceled
    }
}