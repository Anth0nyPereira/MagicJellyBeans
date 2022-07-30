using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CollectableData", menuName = "Collectable Data", order = 51)]
public class CollectableData : ScriptableObject
{
    [SerializeField]
    private string collectableName;
    [SerializeField]
    private Material material;

    public string CollectableName
    { get{ return collectableName; } }

    public Material Material
    { get { return material; } }
}

