using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorListScript : MonoBehaviour
{
    [SerializeField]
    private ColorListEvent colorListEvent;

    [SerializeField]
    private ColorListSO colorList;
   
    
    void Update()
    {
        colorListEvent.Raise(colorList);
    }
}
