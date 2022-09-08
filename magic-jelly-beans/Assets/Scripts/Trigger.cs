using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : Collidable
{

    [SerializeField]
    private VoidEvent lockPauseMenuEvent;

    [SerializeField]
    private VoidEvent showYouEscapedEvent;

    [SerializeField]
    private VoidEvent characterStopsMoving;

    public override void OnCollisionEnter(Collision other)
    {
        // when the player collides with the object, show something to the player?? a text appears or something
        
        if (other.gameObject.tag == "Character")
        {
            Debug.Log("Show you escaped!");
            Debug.Log("Player cannot go to the pause menu");
            Debug.Log("Character needs to stop moving");
            lockPauseMenuEvent.Raise();
            showYouEscapedEvent.Raise();
            characterStopsMoving.Raise();

        }

    }
}
