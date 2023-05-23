using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneTransition1 : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene(1);
    }
}
