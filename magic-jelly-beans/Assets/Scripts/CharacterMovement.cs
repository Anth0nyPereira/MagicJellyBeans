using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;

    // gravity attributes
    private Vector3 velocity;
    private float gravity = -9.81f;

    // collision with ground terrain
    public Transform groundCheck;
    private float groundRadius = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    // walking attributes
    public Transform initialPos;
    public Vector3 direction;
    public float speed = 6f;

    // jumping attributes
    private float jumpHeight = 8.0f;



    void Awake()
    {
        
    }

    
    void Start()
    {
        
    }

    void Update()
    {

        if (!checkIfFallen())
        {
            // check collision with some ground terrain
            isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);
            Debug.Log(isGrounded);

            // reset the velocity when it hits terrain
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }


            // character gravity
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            // character walking
            float horizontalI = Input.GetAxisRaw("Horizontal");
            float verticalI = Input.GetAxisRaw("Vertical");
            direction = new Vector3(horizontalI, 0f, verticalI).normalized;

            handleRotation();//Turn to where is running

            if (direction.magnitude >= 0.1)
            {
                controller.Move(direction * speed * Time.deltaTime);
            }
        }
    }

    bool checkIfFallen()
    {
        if (transform.position.y <= -10)
        {
            velocity.y = -2f;
            transform.position = initialPos.position;
            // Debug.Log(velocity);
            return true;
        }
        return false;
    }

    public void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    void handleRotation()
    {
        Vector3 currentPosition = transform.position;

        Vector3 newPosition = new Vector3(direction.x, 0, direction.z);

        Vector3 positionToLookAt = currentPosition + newPosition;

        transform.LookAt(positionToLookAt);
    }
}