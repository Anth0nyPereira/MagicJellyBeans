using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    /* TODO: make the collectable change player's behavior and destroy it
     * add parameters: collectable data (color and name of material) via scriptable object
     * */
    [SerializeField]
    private string color;

    [SerializeField]
    private ColorListSO colorList;

    public override void OnCollisionEnter(Collision other)
    {
        Debug.Log(other);
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("I'm colliding with the player");
            // do something to the player
            // get the corresponding color that the player should have when colliding with this kind of object
            // destroy the gameObject
            foreach (ColorSO item in colorList.ColorList)
            {
                Debug.Log(item);
            }
        }
    }
}
