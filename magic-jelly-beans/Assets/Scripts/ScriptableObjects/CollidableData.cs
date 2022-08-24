using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Collidable Data", menuName = "Collidable Data", order = 61)]
public class CollidableData : ScriptableObject
{

    [SerializeField]
    private string collidableName;

    [SerializeField]
    private bool isVisible;

    public string CollidableName { get => collidableName; set => collidableName = value; }
    public bool IsVisible { get => isVisible; set => isVisible = value; }
}
