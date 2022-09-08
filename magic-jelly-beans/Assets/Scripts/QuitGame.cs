using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    [SerializeField]
    private CharacterData characterData;

    [SerializeField]
    private CharacterData initialCharacterData;

    [SerializeField]
    private FloatSO stressLevelSO;

    [SerializeField]
    private FloatSO barPosition;

    public void quitGame()
    {
        characterData.Material = initialCharacterData.Material;
        characterData.ParentTransform = initialCharacterData.ParentTransform;
        characterData.GrandfatherTransform = initialCharacterData.GrandfatherTransform;

        stressLevelSO.Value = 50;
        barPosition.Value = 0;

        // UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
