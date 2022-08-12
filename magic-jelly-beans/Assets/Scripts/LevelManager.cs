using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private CollidableListSO listOfCollectables;

    [SerializeField]
    private CollidableListSO listOfObstacles;

    [SerializeField]
    private CollidableListSO listOfGround;

    private GameObject[] collidables;


    public void resetAllCollidables()
    {
        collidables = GameObject.FindGameObjectsWithTag("Collidable");

        foreach (GameObject collidable in collidables)
        {
            collidable.SetActive(true);
        }
    }
}
