using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PauseMenu : MonoBehaviour
{
    public GameObject blackBackground;
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
        Time.timeScale = 0.0f;
        Debug.Log("here");
        blackBackground.SetActive(true);
        enableAll();
    }

    public void resumeGame()
    {
        Time.timeScale = 1.0f;
        this.transform.parent.gameObject.SetActive(false);
        blackBackground.SetActive(false);
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
            ui.gameObject.SetActive(true);
        }
    }

    private void disableAll()
    {
        foreach (GameObject ui in allUIs)
        {
            ui.gameObject.SetActive(false);
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
