using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PauseMenu : MonoBehaviour
{

    [SerializeField]
    private VoidEvent makeCharacterNotToMoveEvent;

    [SerializeField]
    private VoidEvent makeCharacterMoveAgainEvent;

    [SerializeField]
    private VoidEvent resetCharacterEvent;

    [SerializeField]
    private VoidEvent tellManagerToMakeAudioStopEvent;

    [SerializeField]
    private VoidEvent tellManagerToMakeAudioResumeEvent;

    [SerializeField]
    private VoidEvent tellManagerToMakeAudioStartFromTheBeginningEvent;

    private List<GameObject> allUIs;

    private void Awake()
    {
        allUIs = new List<GameObject>();
        int nrChilds = transform.childCount;

        for (int i = 0; i < nrChilds; i++)
        {
            allUIs.Add(transform.GetChild(i).gameObject);
        }


        disableAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pauseGame()
    {
        makeCharacterNotToMoveEvent.Raise();
        tellManagerToMakeAudioStopEvent.Raise();
        // Debug.Break();
        enableAll();
    }

    public void resumeGame()
    {
        makeCharacterMoveAgainEvent.Raise();
        tellManagerToMakeAudioResumeEvent.Raise();
        disableAll();
    }

    public void restart()
    {
        disableAll();
        tellManagerToMakeAudioStartFromTheBeginningEvent.Raise();
        resetCharacterEvent.Raise();
        
    }

    private void saveGame()
    {

    }

    private void mainMenu()
    {

    }

    private void disableOthers(string name)
    {
        foreach (GameObject ui in allUIs)
        {
            if (ui.GetComponent<UserInterface>().uiName.Str != name)
            {
                ui.transform.gameObject.SetActive(false);
            }
        }
    }

    private void enableAll()
    {
        foreach (GameObject ui in allUIs)
        {
            ui.SetActive(true);
        }
    }

    private void disableAll()
    {
        foreach (GameObject ui in allUIs)
        {
            ui.SetActive(false);
        }
    }

    private GameObject getGOBasedOnName(string name)
    {
        foreach (GameObject ui in allUIs)
        {

            if (ui.GetComponent<UserInterface>().uiName.Str == name)
            {
                return ui;
            }
        }
        return null;
    }
}
