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

    public Vector3 direction;
    public float speed = 2f;

    // jumping attributes
    private float jumpHeight = 8.0f;

    [SerializeField]
    private VoidEvent resetCharacterEvent;

    private bool fallingDown;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        father = this.transform.parent.gameObject;
        grandpa = father.transform.parent.gameObject;
        fallingDown = false;
    }

    void Update()
    {
        // I guess it's better to send an event telling that the character is no longer in contact with ground and give that information
        // to this class

        if (!fallingDown)
        {
            grandpa.transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * 0.2f);

            // character walking
            float horizontalI = Input.GetAxisRaw("Horizontal");
            direction = new Vector3(0f, 0f, -horizontalI).normalized;

            if (direction.magnitude >= 0.1)
            {
                father.transform.Rotate(speed * Time.deltaTime * direction * 100, Space.World);
            }

        }
    }

    public Vector3 getVectorBetweenParentCharacter()
    {
        Vector3 direct = (transform.position - father.transform.position).normalized;
        return direct;
    }

    public void resetCharacter()
    {
        resetCharacterEvent.Raise();
    }

    public float getDistanceBetweenPositions(Vector3 pos1, Vector3 pos2)
    {
        Vector3 directionVector = pos2 - pos1;
        float distance = Mathf.Sqrt(Mathf.Pow(directionVector.x, 2) + Mathf.Pow(directionVector.y, 2) + Mathf.Pow(directionVector.z, 2));
        return distance;
    }

    public void makeCharacterFallDown()
    {
        fallingDown = true;
        doFallingDownBehaviour();
    }

    public void doFallingDownBehaviour()
    {
        Debug.Log("called");
        Vector3 initialPosition = grandpa.transform.position;
        
        while (getDistanceBetweenPositions(initialPosition, grandpa.transform.position) <= 2)
        {
            grandpa.transform.Translate(getVectorBetweenParentCharacter() * 100);
            

        }
        Debug.Log("Have a break, have a kit kat");
    }
}