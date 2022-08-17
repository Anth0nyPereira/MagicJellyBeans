using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{


    [SerializeField]
    private FloatSO minStressLevel;

    [SerializeField]
    private FloatSO maxStressLevel;

    private float stressLevel;

    [SerializeField]
    private CharacterData characterData;

    private void Awake()
    {
        stressLevel = computeStartingStressLevel();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private float computeStartingStressLevel()
    {
        float stress = (minStressLevel.Value + maxStressLevel.Value)/2;
        Debug.Log("starting stress level: " + stress);
        return stress;
    }

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
    }

    public void updateMaterialData(Material newMaterial)
    {
        characterData.Material = newMaterial;
    }

    public void updateParentTransformData(Transform newTransform) // this is actually the parent aka "meshCenter" position
    {
        characterData.ParentTransform.Position = newTransform.position;
        characterData.ParentTransform.Rotation = new Vector3(newTransform.rotation.x, newTransform.rotation.y, newTransform.rotation.z);

    }

    public void updateGrandParentTransformData(Transform newTransform) // this is actually the grandfather aka "Character object" position
    {
        characterData.GrandfatherTransform.Position = newTransform.position;
        characterData.GrandfatherTransform.Rotation = new Vector3(newTransform.rotation.x, newTransform.rotation.y, newTransform.rotation.z);

    }
}
