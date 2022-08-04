using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    /* TODO: make the collectable change player's behavior and destroy it
     * add parameters: collectable data (color and name of material) via scriptable object
     * */

    public override void OnCollisionEnter(Collision other)
    {
        Debug.Log(other);
        if (other.gameObject.tag == "Character")
        {
            Debug.Log("I'm colliding with the character");
            // do something to the player
            // get the corresponding color that the player should have when colliding with this kind of object
            // destroy the gameObject
            ColorSO colorSO = getColorBasedOnMaterial(GetComponent<Renderer>().sharedMaterial);
            other.gameObject.GetComponent<Renderer>().material = colorSO.Materials[0];
            Destroy(gameObject);
        }
    }
}
