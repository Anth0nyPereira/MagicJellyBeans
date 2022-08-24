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

    [SerializeField]
    private VoidEvent resetCharacterEvent;

    private bool fallingDown;

    private bool coroutineFinished;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        father = this.transform.parent.gameObject;
        grandpa = father.transform.parent.gameObject;
        fallingDown = false;
        coroutineFinished = false;
    }

    void Update()
    {
        // I guess it's better to send an event telling that the character is no longer in contact with ground and give that information
        // to this class

        if (!fallingDown)
        {
            grandpa.transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * 1.3f);

            // character walking
            float horizontalI = Input.GetAxisRaw("Horizontal");
            direction = new Vector3(0f, 0f, horizontalI).normalized;

            if (direction.magnitude >= 0.1)
            {
                father.transform.Rotate(speed * Time.deltaTime * direction * 100, Space.World);
            }

        }

        if (coroutineFinished)
        {
            resetCharacter();
            coroutineFinished = false;
        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, getVectorBetweenParentCharacter(), out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.Log(getVectorBetweenParentCharacter());
            Debug.Log("Did not Hit");
            makeCharacterFallDown();
            Debug.Break();
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
        StartCoroutine(makeFallingAnimation(whenCoroutineEnds));


        Debug.Log("Have a break, have a kit kat");

        
        
    }

    public IEnumerator makeFallingAnimation(Action whenCEnds)
    {
        Vector3 initialPosition = grandpa.transform.position;
        while (getDistanceBetweenPositions(initialPosition, grandpa.transform.position) <= 2)
        {
            grandpa.transform.Translate(getVectorBetweenParentCharacter() * 0.001f);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        whenCEnds();
    }

    public void whenCoroutineEnds()
    {
        Debug.Log("finished coroutine");
        coroutineFinished = true;
    }

    public void makeCharacterNotFallDown()
    {
        fallingDown = false;
    }
}