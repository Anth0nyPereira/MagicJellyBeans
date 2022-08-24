using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Checkpoint", menuName = "Checkpoint", order = 58)]
public class CheckpointSO : ScriptableObject
{

    [SerializeField]
    private string checkpointName;

    private CharacterData characterData; // will store character actual color, actual stress level and actual position (position of
    // the character when it starts on that specific checkpoint

    [SerializeField]
    private CollidableDataList listOfAvailableCollidables;
}

    
