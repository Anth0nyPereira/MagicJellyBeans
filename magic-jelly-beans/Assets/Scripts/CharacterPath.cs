using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPath : MonoBehaviour
{
    private bool isPaused;
    void Start()
    {
        isPaused = true;
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Level0"), "time", 5));
        iTween.Pause(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isPaused)
        {
            iTween.Pause(gameObject);
            isPaused = true;
        } else if (Input.GetKeyDown(KeyCode.Space) && isPaused)
        {
            iTween.Resume(gameObject);
            isPaused = false;
        }
    }
}
