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
}
