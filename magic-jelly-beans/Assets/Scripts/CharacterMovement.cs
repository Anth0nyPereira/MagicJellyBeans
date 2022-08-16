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
        grandpa.transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * 0.2f);

        getVectorParentCharacter.Raise(getVectorBetweenParentCharacter());

        

        if (!checkIfFallen())
        {

            // character walking
            float horizontalI = Input.GetAxisRaw("Horizontal");
            direction = new Vector3(0f, 0f, -horizontalI).normalized;

            if (direction.magnitude >= 0.1)
            {
                father.transform.Rotate(speed * Time.deltaTime * direction * 100, Space.World);
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
        // rb.useGravity = true;
    }

    public void resetCharacter()
    {
        resetCharacterEvent.Raise();
    }
}