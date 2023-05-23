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

    IEnumerator nextScene()
    {
        loading.SetActive(true);
        yield return new WaitForSeconds(5f);
        loading.SetActive(false);
        gameObject.SetActive(false);
        int chapterSelectionIndex = 1;
        SceneManager.LoadScene(5); //load the chapter Selection index
    }
}
