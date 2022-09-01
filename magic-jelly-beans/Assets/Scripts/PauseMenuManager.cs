using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PauseMenuManager : MonoBehaviour
{
    private bool mPaused = false;

    [SerializeField]
    private VoidEvent pauseGameEvent;

    [SerializeField]
    private VoidEvent resumeGameEvent;

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
        pauseGameEvent.Raise();
        mPaused = true;
    }

    private void resumeGame()
    {
        resumeGameEvent.Raise();
        mPaused = false;
    }
}
