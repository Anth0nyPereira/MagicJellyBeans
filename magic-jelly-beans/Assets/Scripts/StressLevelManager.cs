using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressLevelManager : MonoBehaviour
{
    [SerializeField]
    private Character character;

    public void updateStress(float damage)
    {
        if (damage < 0)
        {
            Debug.Log("Make stress level decrease");
        } else
        {
            Debug.Log("Make stress level increase");
        }

        
    }

    private void decreaseStress(float damage)
    {
        character.decreaseStressLevel(Mathf.Abs(damage));
    }

    private void increaseStress(float damage)
    {
        character.increaseStressLevel(damage);
    }
}
