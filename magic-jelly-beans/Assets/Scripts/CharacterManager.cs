using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    private GameObject go;

    private GameObject mesh;

    public Transform initialPos;

    [SerializeField]
    private CharacterData cData;

    [SerializeField]
    private VoidEvent resetAllCollidables;

    private void Awake()
    {
        mesh = GameObject.FindGameObjectWithTag("Character");
        Debug.Log(mesh);
        go = mesh.transform.parent.gameObject;
    }

    

    public void resetCharacter()
    {
        resetAllCollidables.Raise();
        go.transform.position = cData.ParentTransform.Position;
        go.transform.rotation = Quaternion.Euler(cData.ParentTransform.Rotation);
        mesh.GetComponent<Renderer>().sharedMaterial = cData.Material;
        mesh.transform.position = cData.Transform.Position;
        mesh.transform.rotation = Quaternion.Euler(cData.Transform.Rotation);
        // quaternion.euler is used to convert from Vector3 to Quaternion
    }
}
