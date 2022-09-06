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

    [SerializeField]
    private VoidEvent playDeathAnimationEvent;

    [SerializeField]
    private VoidEvent characterStopsMovingEvent;

    [SerializeField]
    private VoidEvent characterCanMoveAgainEvent;

    private bool flag;

    private float stressLevel;

    private float previousDamage;

    public float StressLevel { get => stressLevel; set => stressLevel = value; }

    private void Awake()
    {
        stressLevel = stressLevelSO.Value;
        flag = true;
    }

    private void Update()
    {
        Debug.Log("STRESSSS LEVEL: " + stressLevel);
        if (flag)
        {
            if (checkIfStressLevelIsOutOfBonds())
            {
                revertDamage();
                PlayDeathAnimation();
            }
                
        }
        
    }

    public void decreaseStressLevel(float dam)
    {
        previousDamage = -dam;
        stressLevel -= dam;
        
    }
    public void increaseStressLevel(float dam)
    {
        previousDamage = dam;
        stressLevel += dam;
        // Debug.Log("new stress level: " + stressLevel);
        
    }

    public void PlayDeathAnimation()
    {
        characterStopsMovingEvent.Raise();
        playDeathAnimationEvent.Raise();
    }

    public void Die()
    {
        Debug.Log("I died rip me :(");
        // play dissolve anim??
        // reset level, character, stress level
        resetCharacterEvent.Raise();
        characterCanMoveAgainEvent.Raise();
        

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

    public void writeNewStressLevelIntoSO()
    {
        if (checkIfStressLevelIsOutOfBonds()) return;
        stressLevelSO.Value = stressLevel;
        // Debug.Break();
    }

    public void resetStressLevel()
    {
        stressLevel = stressLevelSO.Value;
    }

    public void resetFlag()
    {
        flag = true;
    }

    private void OnApplicationQuit()
    {
        stressLevelSO.Value = 50;
    }

    private bool checkIfStressLevelIsOutOfBonds()
    {
        if (stressLevel < 0 || stressLevel > 100)
        {
            return true;
        }
        return false;
    }

    private void revertDamage()
    {
        if (previousDamage < 0)
        {
            stressLevel += Mathf.Abs(previousDamage);
        } else
        {
            stressLevel -= Mathf.Abs(previousDamage);
        }
        previousDamage = 0;
        Debug.Log("stress level reverted: " + stressLevel);
    }

}
