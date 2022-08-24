using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Collidable Data List", menuName = "Collidable Data List", order = 57)]
public class CollidableDataList : ScriptableObject
{

    [SerializeField]
    private List<CollidableData> listOfCollidables;

    public List<CollidableData> ListOfCollidables { get => listOfCollidables; set => listOfCollidables = value; }
}
