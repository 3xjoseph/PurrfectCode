using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chapterSelectionButton : MonoBehaviour
{

    public GameObject stage1Button;
    public GameObject stage2Button;
    public GameObject stage3Button;

    // Start is called before the first frame update
    void Start()
    {
        stage1Button.SetActive(false);
        stage2Button.SetActive(false);
        stage3Button.SetActive(false);
    }

    public void FlipToPage(int pageNumber)
    {
        // Logic to flip to the specified page goes here

        // Check the page number and activate the corresponding button
        if (pageNumber == 4)
        {
            stage1Button.SetActive(true);
            stage2Button.SetActive(false);
            stage3Button.SetActive(false);
        }
        else if (pageNumber == 6)
        {
            stage1Button.SetActive(false);
            stage2Button.SetActive(true);
            stage3Button.SetActive(false);
        }
        else if (pageNumber == 8)
        {
            stage1Button.SetActive(false);
            stage2Button.SetActive(false);
            stage3Button.SetActive(true);
        }
    }
}
