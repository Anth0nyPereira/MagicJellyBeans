using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Color", menuName = "Color", order = 52)]
public class ColorSO : ScriptableObject
{

    [SerializeField]
    private string color;

    [SerializeField]
    private List<Material> materials = new();

    public string Color { get => color; set => color = value; }
    public List<Material> Materials { get => materials; set => materials = value; }
}
