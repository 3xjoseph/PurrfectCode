using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1button : MonoBehaviour
{
    public GameObject loading;
    public void playGame()
    {
        gameObject.SetActive(true);
        loading.SetActive(true);
        StartCoroutine(nextScene());
    }

    IEnumerator nextScene()
    {
        yield return new WaitForSeconds(5f);
        loading.SetActive(false);
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //load the scene of learning 1
    }
}
