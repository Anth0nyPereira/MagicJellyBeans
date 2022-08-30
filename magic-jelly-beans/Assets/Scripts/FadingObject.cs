using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingObject : MonoBehaviour
{

    private float fadeSpeed;


    private void Awake()
    {
        fadeSpeed = 10f;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("fade out");
            StartCoroutine(FadeOutObject());
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(FadeInObject());
        }
    }

    private IEnumerator FadeOutObject()
    {
        while (this.GetComponent<MeshRenderer>().material.color.a > 0)
        {
            Debug.Log("here");
            Color color = this.GetComponent<MeshRenderer>().material.color;
            float fadeAmount = color.a - (fadeSpeed * Time.deltaTime);

            color = new Color(color.r, color.g, color.b, fadeAmount);
            this.GetComponent<MeshRenderer>().material.color = color;
            yield return null;
        }
    }

    private IEnumerator FadeInObject()
    {
        while (this.GetComponent<MeshRenderer>().material.color.a < 1)
        {
            Color color = this.GetComponent<MeshRenderer>().material.color;
            float fadeAmount = color.a + (fadeSpeed * Time.deltaTime);

            color = new Color(color.r, color.g, color.b, fadeAmount);
            this.GetComponent<MeshRenderer>().material.color = color;
            yield return null;
        }
    }

    private void whenFadeOutEnds()
    {
        ;
    }
}
