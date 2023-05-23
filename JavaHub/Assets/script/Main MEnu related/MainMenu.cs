using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject loading, logo, cat;
    public void playGame()
    {
        gameObject.SetActive(true);
        loading.SetActive(true);
        StartCoroutine(nextScene());
        logo.SetActive(false);
        cat.SetActive(false);
    }

    public void quitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    IEnumerator nextScene()
    {
        yield return new WaitForSeconds(2f);
        loading.SetActive(false);
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //load the scene of learning 1
    }
}
