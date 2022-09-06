using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private VoidEvent makeAudioStopEvent;

    [SerializeField]
    private VoidEvent makeAudioResumeEvent;

    [SerializeField]
    private VoidEvent makeAudioStartFromTheBeginningEvent;

    public void makeAudioStop()
    {
        makeAudioStopEvent.Raise();
    }

    public void makeAudioResume()
    {
        makeAudioResumeEvent.Raise();
    }

    public void makeAudioRestart()
    {
        makeAudioStartFromTheBeginningEvent.Raise();
    }
}
