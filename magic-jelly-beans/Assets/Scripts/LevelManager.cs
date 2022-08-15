using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{


    private GameObject[] collidablesGOs; // later this list will be only the collidables that exist after the last checkpoint
    // store collidable data --> name, prefab, position and isVisible I guess??

    [SerializeField]
    private CollidableNameListSO listOfVisibleCollidables;

    private string collidableNameInFocus;
    private GameObject collidableInFocus;

    private List<GameObject> collidables;


    public void Awake()
    {
        collidablesGOs = GameObject.FindGameObjectsWithTag("Collidable");
        foreach (GameObject item in collidablesGOs)
        {
            Debug.Log(item.gameObject.name);
        }
    }


    public void resetAllCollidables()
    {
        // Debug.Log("Function called");

        foreach (StringSO collidableName in listOfVisibleCollidables.ListOfCollidableNames)
        {
            string cName = collidableName.Str;
            foreach (GameObject collidable in collidablesGOs)
            {
                if (cName == collidable.GetComponent<Collidable>().collidableName.Str)
                {
                    collidable.SetActive(true);
                    collidable.GetComponent<Collider>().enabled = true;
                }
            }
            
        }
    }

    public void getLogCollidable(GameObject collidable)
    {
        collidableNameInFocus = collidable.GetComponent<Collidable>().collidableName.Str;
        collidableInFocus = collidable;
        collidables.Add(collidable);
    }

}
