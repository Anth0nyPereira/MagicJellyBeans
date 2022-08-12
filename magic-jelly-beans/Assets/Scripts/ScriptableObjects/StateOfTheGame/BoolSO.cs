using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bool", menuName = "Bool", order = 55)]
public class BoolSO : ScriptableObject
{

    [SerializeField]
    private bool val;

    public bool Val { get => val; set => val = value; }
}
