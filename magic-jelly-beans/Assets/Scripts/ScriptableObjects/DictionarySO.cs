using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dictionary Storage", menuName = "Dictionary Storage", order = 52)]
public class DictionarySO : ScriptableObject
{
    // keys are the color name, which is a string, and the corresponding value is a 
    [SerializeField]
    private string color;

    [SerializeField]
    private List<Material> materials = new();

    public string Color { get => color; set => color = value; }
    public List<Material> Materials { get => materials; set => materials = value; }
}
