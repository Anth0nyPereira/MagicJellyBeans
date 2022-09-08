using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouEscaped : MonoBehaviour
{
    public GameObject youEscapedText;

    public GameObject returnToMainMenu;
    public void showYouEscaped()
    {
        youEscapedText.SetActive(true);
        returnToMainMenu.SetActive(true);
    }
}
