using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingObject : MonoBehaviour
{
    public float timeToFadeIn;
    public float timeToFadeOut;
    private float fadeSpeed;


    private void Awake()
    {
        fadeSpeed = 2f;
    }


    void Update()
    {
        float thisTime = Time.time;
        if (thisTime == timeToFadeOut || Mathf.Abs(thisTime - timeToFadeOut) <= 0.01)
        {
            Debug.Log("fade out");
            StartCoroutine(FadeOutObject());
        } else if (thisTime == timeToFadeIn || Mathf.Abs(thisTime - timeToFadeIn) <= 0.01)
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
