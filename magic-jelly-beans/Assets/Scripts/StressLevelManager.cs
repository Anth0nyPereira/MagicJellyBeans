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
            Debug.Log("Make stress level decrease");
            decreaseStress(damage);
        } else
        {
            Debug.Log("Make stress level increase");
            increaseStress(damage);
        } 
    }

    public void resetBar()
    {
        bar.resetPosition();
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
        sendActualStressLevelEvent.Raise(character.StressLevel);
    }
    
}
