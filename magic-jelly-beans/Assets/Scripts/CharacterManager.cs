using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    [SerializeField]
    private CharacterData cData;

    [SerializeField]
    private CharacterData cInitialData;

    [SerializeField]
    private VoidEvent makeCharacterNotFallDownEvent;

    [SerializeField]
    private VoidEvent resetStressLevelEvent;

    [SerializeField]
    private VoidEvent resetDyingFlagEvent;

    [SerializeField]
    private VoidEvent turnStressLevelDefaultEvent;

    [SerializeField]
    private TransformEvent sendCharacterTransformEvent;

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
    }

    private void Update()
    {
        sendCharacterTransformEvent.Raise(grandpa.transform);
    }

    public void resetCharacter()
    {
        resetStress();

        // resetDyingFlag();

        character.transform.GetChild(0).GetComponent<Renderer>().sharedMaterial = cData.Material;

        setTransform(grandpa, cData.GrandfatherTransform);
        setTransform(father, cData.ParentTransform, true);

        makeCharacterNotFallDownEvent.Raise();

        // quaternion.euler is used to convert from Vector3 to Quaternion
    }

    public void turnDataDefault()
    {
        cData.Material = cInitialData.Material;
        cData.ParentTransform.Position = cInitialData.ParentTransform.Position;
        cData.ParentTransform.Rotation = cInitialData.ParentTransform.Rotation;
        cData.GrandfatherTransform.Position = cInitialData.GrandfatherTransform.Position;
        cData.GrandfatherTransform.Rotation = cInitialData.GrandfatherTransform.Rotation;
        turnStressLevelDefaultEvent.Raise();

    }

    private void resetStress()
    {
        resetStressLevelEvent.Raise();
    }

    private void resetDyingFlag()
    {
        resetDyingFlagEvent.Raise();
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

    private void OnApplicationQuit()
    {
        cData.Material = cInitialData.Material;
        cData.ParentTransform.Position = cInitialData.ParentTransform.Position;
        cData.ParentTransform.Rotation = cInitialData.ParentTransform.Rotation;
        cData.GrandfatherTransform.Position = cInitialData.GrandfatherTransform.Position;
        cData.GrandfatherTransform.Rotation = cInitialData.GrandfatherTransform.Rotation;
    }
}
