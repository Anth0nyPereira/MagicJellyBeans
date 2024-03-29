using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{

    public Collider col;

    public CollidableData collidableData;

    private ColorListSO colorList;

    private bool isVisible;


    public void Awake()
    {
        isVisible = collidableData.IsVisible;
        this.gameObject.SetActive(isVisible);
    }

    public virtual void OnCollisionEnter(Collision other)
    {
        col.enabled = true;
        // Debug.Log("I collided with " + other.gameObject.name);
    }

    public ColorSO getColorBasedOnName(string colorName)
    {
        foreach (ColorSO item in colorList.ColorList)
        {
            if (item.Color == colorName)
            {
                return item;
            }
        }
        return null;
    }

    public ColorSO getColorBasedOnMaterial(Material m)
    {
        foreach (ColorSO item in colorList.ColorList)
        {
            if (item.Materials.Contains(m))
            {
                return item;
            }
        }
        return null;
    }

    public void getColorList(ColorListSO cl)
    {
        colorList = cl;
    }
}
