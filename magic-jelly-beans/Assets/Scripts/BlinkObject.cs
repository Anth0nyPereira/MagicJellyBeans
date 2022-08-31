using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkObject : MonoBehaviour
{
    [SerializeField]
    private float timeToRepeat;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("changeVisibility", 1.0f, timeToRepeat);
    }

    private void changeVisibility()
    {
        if (this.gameObject.activeSelf) this.gameObject.SetActive(false);
        else this.gameObject.SetActive(true);
    }
}
