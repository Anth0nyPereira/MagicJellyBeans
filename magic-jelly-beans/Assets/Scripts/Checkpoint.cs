using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : Trigger
{
    [SerializeField]
    private TransformEvent updateNewParentTransform;

    [SerializeField]
    private TransformEvent updateNewGrandParentTransform;

    [SerializeField]
    private MaterialEvent updateNewCharacterColorMaterial;

    public override void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Character")
        {
            base.OnCollisionEnter(other);


            GameObject father = other.transform.parent.gameObject;
            GameObject grandpa = father.transform.parent.gameObject;

            updateNewParentTransform.Raise(father.GetComponentInParent<Transform>());
            updateNewGrandParentTransform.Raise(grandpa.GetComponentInParent<Transform>());
            updateNewCharacterColorMaterial.Raise(other.gameObject.GetComponent<Renderer>().sharedMaterial);
        }
        

    }
}
