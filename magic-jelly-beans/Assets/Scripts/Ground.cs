using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : Collidable
{
    // [SerializeField]
    // private FloatEvent updateStressLevel; // maybe you use a child trigger and then after passing the water slide,
    // the character obtains some points??

    [SerializeField]
    private VoidEvent reactivateNormalGravity;

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
                deactivateCollider();
                reactivateNormalGravity.Raise();
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
            deactivateCollider();
            reactivateNormalGravity.Raise();
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

   public void deactivateCollider()
    {
        this.GetComponent<Collider>().enabled = false;
    }
}
