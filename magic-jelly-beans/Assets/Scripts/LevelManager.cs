using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{


    private GameObject[] collidables; // later this list will be only the collidables that exist after the last checkpoint
    // store collidable data --> name, prefab, position and isVisible I guess??


    public void Awake()
    {
        collidables = GameObject.FindGameObjectsWithTag("Collidable");
    }


    public void resetAllCollidables()
    {
        Debug.Log("Function called");

        foreach (GameObject collidable in collidables)
        {
            collidable.SetActive(true);
            collidable.GetComponent<Collider>().enabled = true;
        }
    }

}
