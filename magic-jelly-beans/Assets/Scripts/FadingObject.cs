using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingObject : MonoBehaviour
{

    private float fadeSpeed;

    private void Awake()
    {
        fadeSpeed = 0.2f;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(FadeOutObject());
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(FadeInObject());
        }
    }

    private IEnumerator FadeOutObject()
    {
        while (this.GetComponent<Renderer>().material.color.a > 0)
        {
            Color color = this.GetComponent<Renderer>().material.color;
            float fadeAmount = color.a - (fadeSpeed * Time.deltaTime);

            color = new Color(color.r, color.g, color.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = color;
            yield return null;
        }
    }

    private IEnumerator FadeInObject()
    {
        while (this.GetComponent<Renderer>().material.color.a < 1)
        {
            Color color = this.GetComponent<Renderer>().material.color;
            float fadeAmount = color.a + (fadeSpeed * Time.deltaTime);

            color = new Color(color.r, color.g, color.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = color;
            yield return null;
        }
    }
}
