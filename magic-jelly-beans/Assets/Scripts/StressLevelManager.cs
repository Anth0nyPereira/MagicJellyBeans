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
        Debug.Log("resetted stress: " + character.stressLevel);
        sendActualStressLevelEvent.Raise(character.StressLevel);
    }

    public void setDefaultStressLevel()
    {
        character.stressLevelSO.Value = 50;
        character.StressLevel = character.stressLevelSO.Value;
        sendActualStressLevelEvent.Raise(character.StressLevel);
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
        Debug.Log("send actual stress level: " + character.StressLevel);
        // Debug.Break();
        sendActualStressLevelEvent.Raise(character.StressLevel);
    }    
}
