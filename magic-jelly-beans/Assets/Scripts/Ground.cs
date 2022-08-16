using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : Collidable
{
    // [SerializeField]
    // private FloatEvent updateStressLevel; // maybe you use a child trigger and then after passing the water slide,
    // the character obtains some points??

    [SerializeField]
    private VoidEvent makeCharacterFallDownEvent;


    public override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);
    }

    public void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Character")
        {
            Debug.Log("Character is on terrain!!");
            if (checkIfSameColor(other))
            {
                makeCharacterFallDown(other);
            }
            else
            {
                ;
            }
        }
    }

    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Character")
        {
            makeCharacterFallDown(other);
        }
    }

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

    public void makeCharacterFallDown(Collision character)
    {
        deactivateCollider();
        makeCharacterFallDownEvent.Raise();
    }

   public void deactivateCollider()
    {
        this.GetComponent<Collider>().enabled = false;
    }
}
