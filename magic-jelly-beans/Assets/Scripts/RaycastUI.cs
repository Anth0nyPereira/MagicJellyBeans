using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastUI : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToAppear;

    [SerializeField]
    private GameObject objectToDisappear;

    void Update()
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

            } else
            {
                objectToAppear.SetActive(false);
                objectToDisappear.SetActive(true);
            }
        }

    }
}
