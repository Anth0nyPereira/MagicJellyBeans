using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // public CharacterController controller;

    private Rigidbody rb;

    private GameObject parent;

    private GameObject planet;

    // gravity attributes
    private Vector3 velocity;
    private float gravity = -9.81f;

    // collision with ground terrain
    public Transform groundCheck;
    private float groundRadius = 1.0f;
    public LayerMask groundMask;
    private bool isGrounded;

    // walking attributes
    public Transform initialPos;
    //public Transform anotherPos;
    public Vector3 direction;
    public float speed = 2f;

    // jumping attributes
    private float jumpHeight = 8.0f;

    [SerializeField]
    private Vector3Event getVectorParentCharacter;

    [SerializeField]
    private VoidEvent reactivateGroundCollider;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        parent = this.transform.parent.gameObject;
        planet = parent.transform.Find("Planet").gameObject;
    }

    void Update()
    {
        // Debug.Log(transform.position);



        parent.transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * 0.2f);

        getVectorParentCharacter.Raise(getVectorBetweenParentCharacter());

        // Debug.Log(getVectorBetweenParentCharacter());

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
            // rb.MovePosition(velocity * Time.deltaTime);

            // character walking
            float horizontalI = Input.GetAxisRaw("Horizontal");
            // float verticalI = Input.GetAxisRaw("Vertical");
            direction = new Vector3(-horizontalI, 0f, 0f).normalized;

            // handleRotation();//Turn to where is running

            if (direction.magnitude >= 0.1)
            {
                //controller.Move(direction * speed * Time.deltaTime);
                transform.Translate(direction * speed * Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // rb.AddForce(Vector3.left * 10000 * speed);
            }

        } else
        {
            resetCharacter();
        }
    }

    bool checkIfFallen()
    {
        if (transform.position.y <= -3)
        {
            velocity.y = -2f;
            Debug.Log(velocity);
            reactivateGroundCollider.Raise();
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

    public float calculateAngle(Vector3 point1, Vector3 point2, Vector3 point3)
    {
        Vector3 firstVector = point2 - point1;
        firstVector = new Vector3(0, firstVector.y, firstVector.z);
        Vector3 secondVector = point2 - point3;
        secondVector = new Vector3(0, secondVector.y, secondVector.z);

        float angle = Vector3.Angle(firstVector, secondVector); // in rads

        return Mathf.Rad2Deg * angle;
    }

    public Vector3 getVectorBetweenParentCharacter()
    {
        Vector3 direct = (transform.position - parent.transform.position).normalized;
        return direct;
    }

    public void reactivateNormalGravity()
    {
        rb.useGravity = true;
    }

    public void deactivatePlanet()
    {
        planet.SetActive(false);
    }

    public void resetCharacter()
    {
        Destroy(parent.gameObject);
    }
}