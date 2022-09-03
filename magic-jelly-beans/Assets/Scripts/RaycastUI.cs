using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RaycastUI : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToAppear;

    [SerializeField]
    private GameObject objectToDisappear;

    [SerializeField]
    private VoidEvent updatePauseMenuEvent; // each "canvas" will raise a specific event (event that will tell to resume the game,
    // event to restart the game, ...

    void Update()
    {
        makeHoverRaycast();

        if (Input.GetMouseButtonDown(0))
        {
            makeClickRaycast();

        }
    }

    private void makeHoverRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "UI" && hit.collider.name == this.GetComponent<UserInterface>().uiName.Str)
            {
                Debug.Log("UI");
                objectToAppear.SetActive(true);
                objectToDisappear.SetActive(false);

            }
            else
            {
                objectToAppear.SetActive(false);
                objectToDisappear.SetActive(true);
            }
        }
    }

    private void makeClickRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "UI" && hit.collider.name == this.GetComponent<UserInterface>().uiName.Str)
            {
                updatePauseMenuEvent.Raise();
            }
        }
    }
}
