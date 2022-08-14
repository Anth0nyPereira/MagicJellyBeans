using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : Trigger
{
    [SerializeField]
    private TransformEvent updateNewCharacterTransform;

    [SerializeField]
    private MaterialEvent updateNewCharacterColorMaterial;

    [SerializeField]
    private TransformEvent updateNewParentCharacterTransform;

    public override void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Character")
        {
            base.OnCollisionEnter(other);
            updateNewCharacterTransform.Raise(other.gameObject.transform);
            updateNewCharacterColorMaterial.Raise(other.gameObject.GetComponent<Renderer>().sharedMaterial);
            updateNewParentCharacterTransform.Raise(other.gameObject.GetComponentInParent<Transform>());
        }
        

    }
}
