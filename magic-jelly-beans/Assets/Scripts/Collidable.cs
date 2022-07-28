using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{

    public Collider col;

    public virtual void OnCollisionEnter(Collision other)
    {
        Debug.Log("I collided with " + other.gameObject.name);
    }
}
