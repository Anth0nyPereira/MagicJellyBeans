using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressLevelBar : MonoBehaviour
{

    private float maxDistance = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void decreaseStress(float damage)
    {
        float dst = convertScale(damage);
        this.moveBar(-dst);
    }

    public void increaseStress(float damage)
    {
        float dst = convertScale(damage);
        this.moveBar(dst);
    }

    // the bar has 0.3 of length; so, if 0.3 corresponds to 100, a value corresponds to a certain damage
    private float convertScale(float damage)
    {
        float distanceToMove = maxDistance * damage / 100;
        return distanceToMove;
    }

    private void moveBar(float value)
    {
        this.transform.position += new Vector3(value, 0, 0);
    }
}
