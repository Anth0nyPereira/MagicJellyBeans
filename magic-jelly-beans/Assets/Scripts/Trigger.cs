using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : Collidable
{
    public void Start()
    {
       
    }

    public virtual void OnCollisionEnter(Collision other)
    {
        // when the player collides with the object, show something to the player?? a text appears or something
        // Physics.IgnoreCollision(base.GetComponent<Collider>(), other.collider);

    }
}
