using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressLevelManager : MonoBehaviour
{
    [SerializeField]
    private Character character;

    [SerializeField]
    private StressLevelBar bar;

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

    private void decreaseStress(float damage)
    {
        character.decreaseStressLevel(Mathf.Abs(damage));
        bar.decreaseStress(Mathf.Abs(damage));
    }

    private void increaseStress(float damage)
    {
        character.increaseStressLevel(damage);
        bar.increaseStress(damage);
    }
}
