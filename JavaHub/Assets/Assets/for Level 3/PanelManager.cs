using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    public GameObject optionsPanel;

    public void ResumeGame()
    {
        // Add code here to resume the game
        panel.SetActive(false);
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void QuitGame()
    {
        // Add code here to quit the game
        // Load the previous scene (assuming it's the scene with build index 0)
        SceneManager.LoadScene(1);
    }
}
