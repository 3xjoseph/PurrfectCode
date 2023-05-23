using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button2 : MonoBehaviour
{
    [SerializeField] GameObject buttonPage;

    private int currentPage = 1;

    // Function to flip to the next page
    public void NextPage()
    {
        currentPage++;
        // Code to flip to the next page in your book
    }

    // Function to flip to the previous page
    public void PreviousPage()
    {
        currentPage--;
        // Code to flip to the previous page in your book
    }

    // Function to get the current page number
    private int GetCurrentPage()
    {
        return currentPage;
        // Replace this with your own logic to determine the current page number
    }

    // Update the visibility of the buttons based on the current page
    private void UpdateButtonVisibility()
    {
        int currentPage = GetCurrentPage();

        buttonPage.SetActive(currentPage == 6);

    }

    // Update is called once per frame
    void Update()
    {
        UpdateButtonVisibility();
    }
}
