using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Collidable
{
    private string color; // color of the gameObject; it will probably be a scriptable object tho
    private float damage; // damage that the player will receive if he's hit by the obstacle and his color is not the same 
    // as the obstacle itself

    public override void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player was hit by an obstacle!");
        }
    }

    /* TODO: use scriptable object event system to have access to the player (and their parameters)
     * check how the color data will be stored (scriptable object??)
     */
    public bool ifPlayerHasSameColor() 
    {
        string playerColor = "red";
        if (color == playerColor)
        {
            return true;
        }
        return false;
    }
}
