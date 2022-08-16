using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // public CharacterController controller;

    private Rigidbody rb;

    private GameObject father;

    private GameObject grandpa;

    // gravity attributes
    private Vector3 velocity;
    private float gravity = -9.81f;
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

    [SerializeField]
    private VoidEvent resetCharacterEvent;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        father = this.transform.parent.gameObject;
        grandpa = father.transform.parent.gameObject;
    }

    void Update()
    {
        Debug.Log(velocity);



        grandpa.transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * 0.2f);

        getVectorParentCharacter.Raise(getVectorBetweenParentCharacter());

        // Debug.Log(getVectorBetweenParentCharacter());

        if (!checkIfFallen())
        {

            // character gravity
            // velocity.y += gravity * Time.deltaTime;
            // rb.MovePosition(velocity * Time.deltaTime);

            // character walking
            float horizontalI = Input.GetAxisRaw("Horizontal");
            // float verticalI = Input.GetAxisRaw("Vertical");
            direction = new Vector3(0f, 0f, -horizontalI).normalized;
            

            // handleRotation();//Turn to where is running

            if (direction.magnitude >= 0.1)
            {
                //controller.Move(direction * speed * Time.deltaTime);
                father.transform.Rotate(speed * Time.deltaTime * direction * 100, Space.World);

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
        Debug.Log(transform.position.y);
        if (transform.position.y <= -3)
        {
            // velocity.y = -2f;
            // Debug.Log(velocity);
            reactivateGroundCollider.Raise();
            return true;
        }
        return false;
    }

    public Vector3 getVectorBetweenParentCharacter()
    {
        Vector3 direct = (transform.position - father.transform.position).normalized;
        return direct;
    }

    public void reactivateNormalGravity()
    {
        rb.useGravity = true;
    }

    public void resetCharacter()
    {
        resetCharacterEvent.Raise();
    }
}