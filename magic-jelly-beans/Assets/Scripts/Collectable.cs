using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    /* TODO: make the collectable change player's behavior and destroy it
     * add parameters: collectable data (color and name of material) via subscriptable object
     * */
    public override void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("I'm colliding with the player");
            // do something to the player
            // destroy the gameObject

        }
    }
}
