using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressLevelBar : MonoBehaviour
{
    [SerializeField]
    private FloatSO barPosition;

    private float maxDistance = 0.3f;

    public void decreaseStress(float damage)
    {
        float dst = convertScale(damage);
        this.moveBar(dst);
    }

    public void increaseStress(float damage)
    {
        float dst = convertScale(damage);
        this.moveBar(dst);
    }

    public void resetPosition()
    {
        this.transform.localPosition = new Vector3(0, 0, barPosition.Value);
    }

    public void writePosition()
    {
        barPosition.Value = this.transform.localPosition.z;
    }


    // the bar has 0.3 of length; so, if 0.3 corresponds to 100, a value corresponds to a certain damage
    // it can move till 0.15 forward and 0.15 backwards
    private float convertScale(float damage)
    {
        Debug.Log("damage: " + damage);
        // 
        float distanceToMove = maxDistance * damage / 100;
        Debug.Log("distance: " + distanceToMove);
        // Debug.Break();
        return distanceToMove;
    }

    // REMEMBER THAT BECAUSE OF THE WAY YOU BUILT THE LEVEL, YOU NEED TO ALWAYS CHANGE THE SIGNAL BECAUSE YES
    private void moveBar(float value)
    {
        this.transform.localPosition += new Vector3(0, 0, -value);
    }

    private void OnApplicationQuit()
    {
        barPosition.Value = 0;
    }

}
    
