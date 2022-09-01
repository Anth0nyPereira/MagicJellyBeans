using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

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
        this.gameObject.GetComponent<Volume>().enabled = true;
        mPaused = true;
    }

    private void resumeGame()
    {
        Time.timeScale = 1.0f;
        this.gameObject.GetComponent<Volume>().enabled = false;
        mPaused = false;
    }
}
