using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CollectableData", menuName = "Collectable Data", order = 51)]
public class CollectableData : ScriptableObject
{
    [SerializeField]
    private string collectableName;
    [SerializeField]
    private List<Material> materials = new List<Material>();

    public string CollectableName
    { get{ return collectableName; } }

    public List<Material> Materials
    { get { return materials; } }
}

