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
        Debug.Log("Pause Game");
        mPaused = true;
    }

    private void resumeGame()
    {
        resumeGameEvent.Raise();
        Debug.Log("Resume Game");
        mPaused = false;
    }

    public void tellManagerToResumeGame()
    {
        this.resumeGame();
    }
}
