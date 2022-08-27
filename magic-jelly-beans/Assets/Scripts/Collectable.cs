using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    /* TODO: make the collectable change player's behavior and destroy it
     * add parameters: collectable data (color and name of material) via scriptable object
     * */

    private Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override void OnCollisionEnter(Collision other)
    {
        Debug.Log(other);
        if (other.gameObject.tag == "Character")
        {
            Debug.Log("I'm colliding with the character");
            // do something to the player
            // get the corresponding color that the player should have when colliding with this kind of object
            // destroy the gameObject
            DisableCollider();
            ColorSO colorSO = getColorBasedOnMaterial(GetComponent<Renderer>().sharedMaterial);
            Debug.Log(colorSO.Color);
            animator.SetTrigger("dissolve");
            other.gameObject.transform.GetChild(0).GetComponent<Renderer>().material = colorSO.Materials[0];
        }
    }

    public void DisableCollider()
    {
        col.enabled = false;
    }

    public void Remove()
    {
        // Destroy(gameObject);
        this.gameObject.SetActive(false);
    }
}
