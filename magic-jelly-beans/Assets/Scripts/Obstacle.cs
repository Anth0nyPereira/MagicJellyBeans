using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Collidable
{
    private float damage; // damage that the player will receive if he's hit by the obstacle and his color is not the same 
    // as the obstacle itself

    public override void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Character")
        {
            Debug.Log("Character was hit by an obstacle!");
        }
    }

    /* TODO: use scriptable object event system to have access to the player (and their parameters)
     * check how the color data will be stored (scriptable object??)
     */
    public bool ifPlayerHasSameColor(Collision character) 
    {
        ColorSO colorSO = getColorBasedOnMaterial(GetComponent<Renderer>().sharedMaterial);
        Material foundMaterial = colorSO.Materials[0];
        if (foundMaterial == character.gameObject.GetComponent<Renderer>().sharedMaterial)
        {
            return true;
        }
        return false;
    }
}
