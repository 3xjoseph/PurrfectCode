using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class promptSnakeScript : MonoBehaviour
{
   
    //go Back to chapter Selection
    public void onProceed()
    {
        int chapterSelectionIndex = 1;
        SceneManager.LoadScene(chapterSelectionIndex); //load the chapter Selection index
    }
}
