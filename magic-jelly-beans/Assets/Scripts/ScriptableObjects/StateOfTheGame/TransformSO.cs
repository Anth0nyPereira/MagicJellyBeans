using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Transform", menuName = "Transform", order = 59)]
public class TransformSO : ScriptableObject
{

    [SerializeField]
    private Vector3 position;

    [SerializeField]
    private Vector3 rotation;

    public Vector3 Position { get => position; set => position = value; }
    public Vector3 Rotation { get => rotation; set => rotation = value; }
}
