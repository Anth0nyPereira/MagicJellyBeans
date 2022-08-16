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

    [SerializeField]
    private VoidEvent resetCharacterEvent;

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

        } else
        {
            resetCharacter();
        }
    }

    bool checkIfFallen()
    {
        if (transform.position.y <= -1)
        {
            reactivateGroundCollider.Raise();
            return true;
        }
        return false;
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
        Debug.Log("here");
        planet.SetActive(false);
        this.GetComponent<GravityController>().enabled = false;
    }

    public void resetCharacter()
    {
        planet.SetActive(true);
        resetCharacterEvent.Raise();
    }
}