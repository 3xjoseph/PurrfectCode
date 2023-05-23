using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goBack2 : MonoBehaviour
{
    public GameObject loading;
    public void GoBack()
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
        SceneManager.LoadScene(6); //load the scene of learning 1
    }
}
