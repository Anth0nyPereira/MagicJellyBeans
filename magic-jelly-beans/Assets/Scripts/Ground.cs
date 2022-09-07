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

    private bool characterIsGround;

    public override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);
    }

    public void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Character")
        {
            // Debug.Log("Character is on terrain!!");
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

    /*
    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Character")
        {
            // before falling down, check if the character is colliding with another ground, if not, then make character fall down
            if (characterIsGround)
            {
                Debug.Log("character is ground");
            } else
            {
                makeCharacterFallDown(other);
            }
            characterIsGround = false;
            
        }
    }
    */

    public bool checkIfSameColor(Collision character)
    {
        ColorSO colorSO = getColorBasedOnMaterial(GetComponent<Renderer>().sharedMaterial);
        Material foundMaterial = colorSO.Materials[0];
        if (foundMaterial == character.transform.GetChild(0).GetComponent<Renderer>().sharedMaterial)
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

    public void characterIsStillOnGround()
    {
        characterIsGround = true;
    }
}
