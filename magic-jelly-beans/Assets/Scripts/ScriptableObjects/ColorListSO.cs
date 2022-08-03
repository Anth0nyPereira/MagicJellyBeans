using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Colors", menuName = "Colors", order = 53)]
public class ColorListSO : ScriptableObject
{
    [SerializeField]
    private List<ColorSO> colorList;

    public List<ColorSO> ColorList { get => colorList; set => colorList = value; }
}
