using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Data", menuName = "Character Data", order = 60)]
public class CharacterData : ScriptableObject
{

    [SerializeField]
    private TransformSO transform;

    [SerializeField]
    private Material material;

    [SerializeField]
    private TransformSO parentTransform;

    [SerializeField]
    private TransformSO grandfatherTransform;

    public TransformSO Transform { get => transform; set => transform = value; }
    public Material Material { get => material; set => material = value; }
    public TransformSO ParentTransform { get => parentTransform; set => parentTransform = value; }
    public TransformSO GrandfatherTransform { get => grandfatherTransform; set => grandfatherTransform = value; }
}
