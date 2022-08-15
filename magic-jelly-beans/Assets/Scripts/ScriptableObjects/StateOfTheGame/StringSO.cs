using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New String SO", menuName = "String SO", order = 56)]
public class StringSO : ScriptableObject
{

    [SerializeField]
    private string str;

    public string Str { get => str; set => str = value; }
}
