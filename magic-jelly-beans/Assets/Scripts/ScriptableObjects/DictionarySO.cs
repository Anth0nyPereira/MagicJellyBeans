using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dictionary Storage", menuName = "Dictionary Storage", order = 52)]
public class DictionarySO : ScriptableObject
{
    [SerializeField]
    private List<string> keys = new();

    [SerializeField]
    private List<Material> values = new();

    public List<string> Keys { get => keys; set => keys = value; }
    public List<Material> Values { get => values; set => values = value; }
}
