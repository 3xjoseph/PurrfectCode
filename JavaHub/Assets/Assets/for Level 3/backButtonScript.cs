using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backButtonScript : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject nextPanel;

    public void GoBack()
    {
        currentPanel.SetActive(false);
        nextPanel.SetActive(true);
    }
}
