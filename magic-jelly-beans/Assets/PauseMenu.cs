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
        // Time.timeScale = 0.3f;
        // makeCharacterNotToMoveEvent.Raise();
        Debug.Log("FUCKING PAUSE OK");
        // Debug.Break();
        enableAll();
    }

    public void resumeGame()
    {
        Time.timeScale = 1.0f;
        // makeCharacterMoveAgainEvent.Raise();
        disableAll();
    }

    private void goToControls()
    {
        disableOthers("controls");
    }

    private void restart()
    {

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
