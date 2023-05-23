using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage3 : MonoBehaviour
{
    public GameObject loading, statObjs;
    public void proceed()
    {
        gameObject.SetActive(true);
        loading.SetActive(true);
        statObjs.SetActive(false);
        StartCoroutine(nextScene());
    }

    IEnumerator nextScene()
    {
        yield return new WaitForSeconds(3f);
        loading.SetActive(false);
        gameObject.SetActive(false);
        SceneManager.LoadScene(6); //load the scene of learning 1
    }
}
