using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOverObject : MonoBehaviour
{
    public GameObject objectToAppear;
    public GameObject objectToDisappear;

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
        objectToDisappear.SetActive(false);
        objectToAppear.SetActive(true);
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
        objectToAppear.SetActive(false);
        objectToDisappear.SetActive(true);
    }
}
