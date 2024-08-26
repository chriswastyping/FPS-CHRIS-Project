using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Vector3 screenPosition;
    
    [Range(50, 200)] [SerializeField] private float mouseSensitivity = 100.0f;
    
    // Rotating based on player object
    public Transform orientation;
    private float xRotation = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        screenPosition = Input.mousePosition;
            
        // Mouse Movement & Look Direction

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; 
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        
        xRotation -= mouseY; 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotate Camera
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        orientation.Rotate(Vector3.up * mouseX);
    }
}
