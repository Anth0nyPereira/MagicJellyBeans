using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerChangeScene : MonoBehaviour
{
    [SerializeField]
    private float seconds;

    [SerializeField]
    private string nameOfNextScene;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > seconds)
        {
            changeScene();
        }
    }

    public void skipIntro()
    {
        changeScene();
    }

    private void changeScene()
    {
        SceneManager.LoadScene(nameOfNextScene, LoadSceneMode.Single);
    }


}
