using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneItemCollector : MonoBehaviour
{
    private int pages = 0;
    [SerializeField] private Text pagesText;
    [SerializeField] private Canvas completedCanvas;

    private void Start()
    {
        completedCanvas.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Page"))
        {
            Destroy(collision.gameObject);
            pages++;
            pagesText.text = "Pages: " + pages;

            if (pages >= 3)
            {
                completedCanvas.gameObject.SetActive(true);
            }
        }
    }
}
