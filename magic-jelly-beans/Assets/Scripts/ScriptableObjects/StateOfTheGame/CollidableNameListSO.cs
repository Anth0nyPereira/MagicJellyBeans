using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Collidable Name List", menuName = "Collidable Name List", order = 57)]
public class CollidableNameListSO : ScriptableObject
{

    [SerializeField]
    private List<StringSO> listOfCollidableNames;

    public List<StringSO> ListOfCollidableNames { get => listOfCollidableNames; set => listOfCollidableNames = value; }
}
