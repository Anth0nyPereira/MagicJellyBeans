using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    private bool mPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!mPaused) pauseGame();
            else resumeGame();
        }
    }

    private void pauseGame()
    {
        Time.timeScale = 0.0f;
        mPaused = true;
    }

    private void resumeGame()
    {
        Time.timeScale = 1.0f;
        mPaused = false;
    }
}
