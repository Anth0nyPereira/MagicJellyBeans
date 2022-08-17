using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    public Transform initialPos;

    [SerializeField]
    private CharacterData cData;

    [SerializeField]
    private VoidEvent makeCharacterNotFallDownEvent;

    private GameObject character; // the child one, actually

    private GameObject father;

    private GameObject grandpa;

    private void Awake()
    {
        character = GameObject.FindGameObjectWithTag("Character"); // the one called mesh
        father = character.transform.parent.gameObject; // the one called meshCenter
        grandpa = father.transform.parent.gameObject; // the one called Character

        setTransform(grandpa, cData.GrandfatherTransform);
        setTransform(father, cData.ParentTransform, true);
        setTransform(character, cData.Transform, true);
    }

    public void resetCharacter()
    {
        character.GetComponent<Renderer>().sharedMaterial = cData.Material;
        
        setTransform(grandpa, cData.GrandfatherTransform);
        setTransform(father, cData.ParentTransform, true);
        setTransform(character, cData.Transform, true);


        makeCharacterNotFallDownEvent.Raise();

        // quaternion.euler is used to convert from Vector3 to Quaternion
    }

    private void setTransform(GameObject obj, TransformSO trans, bool localSpace = false)
    {
        if (!localSpace)
        {
            obj.transform.position = trans.Position;
            obj.transform.rotation = Quaternion.Euler(trans.Rotation);
        } else
        {
            obj.transform.localPosition = trans.Position;
            obj.transform.localRotation = Quaternion.Euler(trans.Rotation);
        }
        
    }
}
