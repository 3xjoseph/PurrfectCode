using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject loading;
    public void playGame()
    {
        gameObject.SetActive(true);
        loading.SetActive(true);
        StartCoroutine(nextScene());
    }

    IEnumerator nextScene()
    {
        yield return new WaitForSeconds(3f);
        loading.SetActive(false);
        gameObject.SetActive(false);
        SceneManager.LoadScene(3); //load the scene of learning 1
    }
}
