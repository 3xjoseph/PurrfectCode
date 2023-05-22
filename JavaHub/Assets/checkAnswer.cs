using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class checkAnswer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click()
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.name;
        if (buttonName=="choiceC")
            Debug.Log("your answer is correct "+ buttonName);
        else
            Debug.Log("your answer is incorrect " + buttonName);
    }
}
