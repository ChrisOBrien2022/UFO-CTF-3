using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BluePlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Vector2 movementInput;
    public string team = "Blue"; // Add a team variable for the Blue player
    private bool isMoving;

    // Reference to the Input Action Asset
    public InputActionAsset inputActionAsset;

    // Reference to the Input Action Map
    private InputActionMap playerControlsMap;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerControlsMap = inputActionAsset.FindActionMap("BluePlayerControls");
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
        if (isMoving)
        {
            Vector3 movement = new Vector3(movementInput.x, 0f, movementInput.y).normalized * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + movement);
        }
    }


    private void OnMoveStarted(InputAction.CallbackContext context)
    {
        // Movement action started
        isMoving = true;

    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        // Movement action performed
        movementInput = context.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        // Movement action canceled
        isMoving = false;

        movementInput = Vector2.zero; // Stop movement when action is canceled
    }
}
