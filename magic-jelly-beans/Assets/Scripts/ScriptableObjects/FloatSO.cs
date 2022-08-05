using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Float", menuName = "Float", order = 54)]
public class FloatSO : ScriptableObject
{

    [SerializeField]
    private float val;

    public float Value { get => val; set => val = value; }
}
