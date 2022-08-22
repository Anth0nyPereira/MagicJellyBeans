using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrigger : Trigger
{

    [SerializeField]
    private VoidEvent characterIsStillOnGroundEvent;

    public override void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Character")
        {
            characterIsStillOnGroundEvent.Raise();
        }

    }
}
