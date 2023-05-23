using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class promptSnakeScript : MonoBehaviour
{
    public GameObject loading;
    //go Back to chapter Selection
    public void onProceed()
    {
        gameObject.SetActive(true);
        StartCoroutine(nextScene());
    }
    public void onProceed1()
    {
        gameObject.SetActive(true);
        StartCoroutine(procceedScene());
    }

    IEnumerator nextScene()
    {
        loading.SetActive(true);
        yield return new WaitForSeconds(5f);
        loading.SetActive(false);
        gameObject.SetActive(false);
        int chapterSelectionIndex = 1;
        SceneManager.LoadScene(5); //load the assessment index
    }

    IEnumerator procceedScene()
    {
        loading.SetActive(true);
        yield return new WaitForSeconds(5f);
        loading.SetActive(false);
        gameObject.SetActive(false);
        int chapterSelectionIndex = 1;
        SceneManager.LoadScene(1); //load the assessment index
    }
}
