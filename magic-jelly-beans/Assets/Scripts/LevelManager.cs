using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{


    private GameObject[] collidablesGOs; // later this list will be only the collidables that exist after the last checkpoint
    // store collidable data --> name, position and isVisible I guess??

    [SerializeField]
    private CollidableDataList listOfVisibleCollidables;

    [SerializeField]
    private CollidableDataList listOfObstacles;

    public void Awake()
    {
        collidablesGOs = GameObject.FindGameObjectsWithTag("Collidable");
    }

    public void makeCharacterNotFallDown()
    {
        resetObstacleFlags();
        resetAllCollidables();
    }

    private void resetAllCollidables() // I think I just need to put here collectables and grounds
    {
        foreach (CollidableData collidableData in listOfVisibleCollidables.ListOfCollidables)
        {
            string cName = collidableData.CollidableName;
            
            foreach (GameObject collidable in collidablesGOs)
            {
                // Debug.Log(collidable.GetComponent<Collidable>().collidableData.CollidableName);
                if (cName == collidable.GetComponent<Collidable>().collidableData.CollidableName)
                {
                    // Debug.Log(cName);
                    collidable.SetActive(true);
                    collidable.GetComponent<Collider>().enabled = true;
                }
            }
            
        }
    }

    private void resetObstacleFlags()
    {
        foreach (CollidableData obstacleData in listOfObstacles.ListOfCollidables)
        {
            string oName = obstacleData.CollidableName;
            // Debug.Log(oName);
            GameObject obstacle = GameObject.Find(oName);
            // Debug.Log(obstacle);
            obstacle.GetComponent<Obstacle>().resetCollisionFlag();
        }
    }
}
