using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Collidable
{
    [SerializeField]
    private FloatSO damage; // damage that the player will receive if he's hit by the obstacle and their colors are not the same 

    [SerializeField]
    private FloatEvent updateStressLevel;

    private bool firstCollision;

    private GameObject father;
    private GameObject grandpa;

    [SerializeField]
    private VoidEvent tellCharacterToStopMovingEvent;

    [SerializeField]
    private VoidEvent tellCharacterCanMoveAgainEvent;

    public void Awake()
    {
        firstCollision = true;
        
    }

    public override void OnCollisionEnter(Collision other)
    {
        Debug.Log("entered oncollisionenter");
        if (other.gameObject.tag == "Character")
        {
            Debug.Log("Character was hit by an obstacle!");
            if (checkIfSameColor(other))
            {
                Debug.Log("Character and obstacle have the same color, so character can pass through and damage/stress points decrease");
                characterCanPass(other);
            } else
            {
                Debug.Log("They have not the same color, character collides once with the obstacle, is pushed backwards and then can pass through; character stress points increase");
                characterCannotPass(other);
            }
        }
    }

    /* TODO: use scriptable object event system to have access to the player (and their parameters)
     * check how the color data will be stored (scriptable object??)
     */
    public bool checkIfSameColor(Collision character) 
    {
        ColorSO colorSO = getColorBasedOnMaterial(GetComponent<Renderer>().sharedMaterial);
        Material foundMaterial = colorSO.Materials[0];
        if (foundMaterial == character.gameObject.GetComponent<Renderer>().sharedMaterial)
        {
            return true;
        }
        return false;
    }

    public void characterCanPass(Collision character)
    {
        Physics.IgnoreCollision(base.GetComponent<Collider>(), character.collider);
        Debug.Log("Hurraaayyyyy!! Decrease stress level");

        // invoke event to make character's stress level decrease
        updateStressLevel.Raise(-damage.Value);
    }

    public void characterCannotPass(Collision character)
    {
        if (firstCollision)
        {
            Debug.Log("First time colliding, character should be pulled back!");
            father = character.transform.parent.gameObject;
            grandpa = father.transform.parent.gameObject;

            // grandpa should stop moving
            tellCharacterToStopMovingEvent.Raise();
            //grandpa.GetComponent<Rigidbody>().AddForce(-Vector3.forward * 40);

            applyForce();


            Debug.Log("Autch!! I received some damage that is converted in stress amount!!");
            firstCollision = false;

            // invoke event to make character's stress level increase
            updateStressLevel.Raise(damage.Value);

        } else // second time colliding
        {
            Physics.IgnoreCollision(base.GetComponent<Collider>(), character.collider);
        }
    }

    public void applyForce()
    {
        StartCoroutine(doForceForFixedTime(whenCoroutineEnds));

    }

    public IEnumerator doForceForFixedTime(Action whenCEnds)
    {
        
        grandpa.GetComponent<Rigidbody>().AddForce(-Vector3.forward * 40);
        yield return new WaitForSeconds(2);
        whenCEnds();
    }

    public void whenCoroutineEnds()
    {
        grandpa.GetComponent<Rigidbody>().velocity = Vector3.zero;
        grandpa.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        // character can move again
        tellCharacterCanMoveAgainEvent.Raise();

    }

    public void dissipateAllForces()
    {

    }
}
