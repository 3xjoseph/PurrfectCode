using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class promptScript : MonoBehaviour
{

    // Start is called before the first frame update
    public void onRestart()
    {
        // Restart the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void onBackMenu()
    {
        int learning1_index = 4;
        SceneManager.LoadScene(learning1_index);
    }
}
