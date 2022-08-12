using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Collidable List", menuName = "Collidable List", order = 57)]
public class CollidableListSO : ScriptableObject
{

    [SerializeField]
    private List<CollidableData> lst;

    public List<CollidableData> Lst { get => lst; set => lst = value; }
}
