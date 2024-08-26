using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Speed")]
    private float horizontalInput;
    private float verticalInput;
    
    [Range(1, 20)] [SerializeField] private float speed = 10.0f;

    public CharacterController controller;

    [Range(50, 200)] [SerializeField] private float mouseSensitivity = 100.0f;

    public Transform orientation;

    private float xRotation = 0f;
    private float yRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (orientation == null)
        {
            orientation = transform; // Reset player's transform
        }
    }

    private void Update()
    {
        // Mouse Movement & Look Direction

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; 
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;  // Subtract to invert the control to match typical FPS behavior
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotate Camera and Player
        orientation.localRotation = Quaternion.Euler(0f, yRotation, 0f); // Rotate around the Y-axis for yaw
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f); // Rotate the camera for pitch and yaw

        // WASD Movement
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }

        transform.Translate(movement * Time.deltaTime * speed, Space.World);
    }
}