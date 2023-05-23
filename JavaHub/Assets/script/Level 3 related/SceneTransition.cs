using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
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
        SceneManager.LoadScene(0); //load the scene of learning 1
    }
}
