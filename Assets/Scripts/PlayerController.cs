using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Speed")]
    private float xInput;
    private float zInput;
    
    [Range(1, 20)] [SerializeField] private float speed = 10.0f;
    [Range(-20, 0)] [SerializeField] private float gravity = -9.81f;
    
   
    [SerializeField] private CharacterController controller;
    //Jumping
    [SerializeField] private Transform groundCheck;

    [SerializeField] private float jumpHeight = 3f;
    // Sphere radius
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    
    private Vector3 velocity;
    private bool isGrounded;
    
    private void Update()
    {
        // Bullet

       
        // Jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("Jump");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        // WASD Movement
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * xInput + transform.forward * zInput;

        controller.Move(movement * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

     
    }
}