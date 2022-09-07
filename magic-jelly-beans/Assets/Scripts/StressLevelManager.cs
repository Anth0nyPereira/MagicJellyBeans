using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressLevelManager : MonoBehaviour
{
    [SerializeField]
    private Character character;

    [SerializeField]
    private StressLevelBar bar;

    [SerializeField]
    private FloatEvent sendActualStressLevelEvent;

    public void updateStress(float damage)
    {
        if (damage < 0)
        {
            //Debug.Log("Make stress level decrease");
            decreaseStress(damage);
        } else
        {
            // Debug.Log("Make stress level increase");
            increaseStress(damage);
        } 
    }

    public void resetBar()
    {
        Debug.Log("reset bar");
        bar.resetPosition();
    }

    public void resetStress()
    {
        character.resetStressLevel();
    }

    public void setDefaultStressLevel()
    {
        character.stressLevelSO.Value = 50;
        character.stressLevel = character.stressLevelSO.Value;
    }

    private void decreaseStress(float damage)
    {
        character.decreaseStressLevel(Mathf.Abs(damage));
        bar.decreaseStress(damage);
        sendActualStressLevel();
    }

    private void increaseStress(float damage)
    {
        character.increaseStressLevel(damage);
        bar.increaseStress(damage);
        sendActualStressLevel();
    }

    private void sendActualStressLevel()
    {
        if (character.StressLevel < 0 || character.StressLevel > 100) return;
        sendActualStressLevelEvent.Raise(character.StressLevel);
    }    
}
