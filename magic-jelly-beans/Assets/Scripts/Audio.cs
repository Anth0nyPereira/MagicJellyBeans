using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private AudioSource m_AudioSource;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }
    public void stopAudio()
    {
        m_AudioSource.Pause();
    }

    public void resumeAudio()
    {
        m_AudioSource.UnPause();
    }

    public void restartAudio()
    {
        m_AudioSource.Play();
    }
}
