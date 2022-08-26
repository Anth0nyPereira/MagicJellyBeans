using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private FloatSO stressLevelSO;

    [SerializeField]
    public CharacterData characterData;

    [SerializeField]
    private VoidEvent resetCharacterEvent;

    private bool flag;

    private float stressLevel;

    private void Awake()
    {
        stressLevel = stressLevelSO.Value;
        flag = true;
    }

    private void Update()
    {
        if (flag)
        {
            if (stressLevel <= 0 || stressLevel >= 100)
            {
                Die();
                flag = false;
            }
        }
        
    }

    /*
    private float computeStartingStressLevel()
    {
        float stress = (minStressLevel.Value + maxStressLevel.Value)/2;
        Debug.Log("starting stress level: " + stress);
        return stress;
    }
    */

    public void decreaseStressLevel(float dam)
    {
        stressLevel -= dam;
    }
    public void increaseStressLevel(float dam)
    {
        stressLevel += dam;
        Debug.Log("new stress level: " + stressLevel);
    }

    public void Die()
    {
        Debug.Log("I died rip me :(");
        // play dissolve anim??
        // reset level, character, stress level
        resetCharacterEvent.Raise();
        flag = true;

    }

    public void updateMaterialData(Material newMaterial)
    {
        characterData.Material = newMaterial;
    }

    public Vector3 getTransformInEulerAngles(Quaternion quaternion)
    {
        return quaternion.eulerAngles;
    }
    public void updateParentTransformData(Transform newTransform) // this is actually the parent aka "meshCenter" position
    {
        Vector3 rotationTransform = getTransformInEulerAngles(newTransform.rotation);
        characterData.ParentTransform.Position = newTransform.localPosition;
        characterData.ParentTransform.Rotation = new Vector3(rotationTransform.x, rotationTransform.y, rotationTransform.z);

    }

    public void updateGrandParentTransformData(Transform newTransform) // this is actually the grandfather aka "Character object" position
    {
        Vector3 rotationTransform = getTransformInEulerAngles(newTransform.rotation);
        characterData.GrandfatherTransform.Position = newTransform.position;
        characterData.GrandfatherTransform.Rotation = new Vector3(rotationTransform.x, rotationTransform.y, rotationTransform.z);

    }

    public void resetStressLevel()
    {
        stressLevel = stressLevelSO.Value;
    }
}
