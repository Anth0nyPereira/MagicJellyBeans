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

    private GameObject[] checkpoints;

    private List<GameObject> animatedObstacles;

    public void Awake()
    {
        collidablesGOs = GameObject.FindGameObjectsWithTag("Collidable"); // ground and collectables
        checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        animatedObstacles = new List<GameObject>();

        foreach (CollidableData obstacleData in listOfObstacles.ListOfCollidables)
        {
            string oName = obstacleData.CollidableName;
            GameObject obstacle = GameObject.Find(oName);
            // Debug.Log(obstacle);
            if (obstacle.GetComponent<Animator>() != null) animatedObstacles.Add(obstacle);
        }
    }

    public void makeCharacterNotFallDown()
    {
        resetObstacleFlags();
        resetAllCollidables();
        resetObstacleAnimator();
    }

    public void turnOnCheckpointColliders()
    {
        foreach (GameObject ch in checkpoints)
        {
            ch.GetComponent<Collider>().enabled = true;
        }
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
            //Debug.Log(obstacle.GetComponent<Obstacle>().firstCollision);
        }
    }

    private void resetObstacleAnimator()
    {
        foreach (GameObject animatedObstacle in animatedObstacles)
        {
            animatedObstacle.GetComponent<Animator>().enabled = true;
        }
    }

   
}
