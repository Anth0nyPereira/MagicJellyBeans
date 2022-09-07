using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private string nameOfNextScene;

    public void changeScene()
    {
        SceneManager.LoadScene(nameOfNextScene, LoadSceneMode.Single);
    }
}
