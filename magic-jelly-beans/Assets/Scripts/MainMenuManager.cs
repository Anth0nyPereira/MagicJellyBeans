using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    private bool flag;

    [SerializeField]
    private VoidEvent stopTextFromBlinkingEvent;
    // Start is called before the first frame update
    void Awake()
    {
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && flag)
        {
            this.transform.GetChild(3).gameObject.SetActive(false);
            this.transform.GetChild(4).gameObject.SetActive(false);
            this.transform.GetChild(1).gameObject.SetActive(true);
            this.transform.GetChild(2).gameObject.SetActive(true);
            flag = false;
            stopTextFromBlinkingEvent.Raise();
        }
    }
}
