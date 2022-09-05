using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerEnableDisableGameObject : MonoBehaviour
{
    [SerializeField]
    private float timeToEnable;

    [SerializeField]
    private float timeToDisable;

    private GameObject thisGameObject;

    private void Awake()
    {
        thisGameObject = this.gameObject;
        // this.gameObject.SetActive(false);
    }
    void Update()
    {
        Debug.Log(Time.time);
        if (Time.time > timeToDisable)
        {
            thisGameObject.SetActive(false);
            return;

        } else if (Time.time > timeToEnable)
        {
            Debug.Log("true");
            thisGameObject.SetActive(true);
            return;
        }
    }
}
