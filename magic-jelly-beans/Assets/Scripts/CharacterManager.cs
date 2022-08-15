using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    public GameObject prefab;

    public Transform initialPos;

    [SerializeField]
    private CharacterData cData;

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
        Instantiate(prefab, cData.ParentTransform.Position, Quaternion.identity);
        GameObject mesh = prefab.transform.Find("mesh").gameObject;
        prefab.transform.Find("mesh").GetComponent<Renderer>().sharedMaterial = cData.Material;
        mesh.transform.position = cData.Transform.Position;
        mesh.transform.rotation = Quaternion.Euler(cData.Transform.Rotation);
        // quaternion.euler is used to convert from Vector3 to Quaternion
    }
}
