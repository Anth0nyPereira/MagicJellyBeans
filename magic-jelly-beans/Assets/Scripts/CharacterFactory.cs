using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFactory : MonoBehaviour
{

    public GameObject prefab;

    public Transform initialPos;

    [SerializeField]
    private VoidEvent resetAllCollidables;

    public void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Character").Length < 1)
        {
            createCharacter();
        }
    }

    public void createCharacter()
    {
        resetAllCollidables.Raise();
        Instantiate(prefab, initialPos.position, Quaternion.identity);
    }
}
