using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Collidable
{
    private float damage; // damage that the player will receive if he's hit by the obstacle and his color is not the same 
    // as the obstacle itself

    private bool firstCollision;

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
    }

    public void characterCannotPass(Collision character)
    {
        if (firstCollision)
        {
            Debug.Log("First time colliding, character should be pulled back!");
            character.gameObject.GetComponent<Rigidbody>().AddForce(-Vector3.forward * 2000);
            firstCollision = false;
        }
    }
}
