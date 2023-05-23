using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class checkAnswer2 : MonoBehaviour
{

    public GameObject eHeart;
    public GameObject cHeart;
    //public GameObject pUpDialog;
    public Text qstn;//, prmpt;
    public InputField player;
    public GameObject sObj;
    public GameObject cObj;


    int ind = 0;
    String[] sagot = { "(a+b+c)*3/2", "hi.toUpperCase()", "x>y", "else", "switch(remarks)" };
    String[] questions = {
        "Specify the missing code that will print the sum of all the value of the given variables after getting the product when it is multiplied by 3, and also its quotient when divided by 2. The answer must be 9.",
        "Print the string named hi in all uppercase letters.",
        "Specify the missing code that would output “true” based on the given variables.",
        "Specify the correct code that would print “x is less than 30” if the value of the variable x is 23.",
        "Indicate the missing part that would print “Passed” based on the given remarks while using the switch statement."
    };


    public void click()
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.name; //get the name of the button has been clicked
        string ans = player.text;
        Sagot(ans);

    }

    private void Sagot(String buttonName)
    {
        //correct answer
        if (player.text == sagot[ind])
        {
            catScript cat = cObj.GetComponent<catScript>();
            cat.Move();
            //while the question is answered correctly it will go to the next index of the array of questions
            RHeart(eHeart, false); //reduce the heart of enemy

            //change the questions
            StartCoroutine(WTProceed());
            ind++;

        }
        //wrong answer
        else
        {
            snakeScript snake = sObj.GetComponent<snakeScript>();
            snake.Move();
            RHeart(cHeart, true); //reduce the heart of cat
        }

    }

    private void prcd(String questions)
    {
        qstn.text = questions; //change the question

    }

    //remove a heart from the user/enemy 
    public void RHeart(GameObject heart, bool isCat)
    {
        if (heart.transform.childCount > 1)
        {
            Transform lastHeart = heart.transform.GetChild(heart.transform.childCount - 1);
            Destroy(lastHeart.gameObject);
        }
        //no more lives
        else
        {
            Transform lastHeart = heart.transform.GetChild(heart.transform.childCount - 1);
            String promptMessage;
            if (isCat)
                promptMessage = "Sorry you died in the battle";
            else
                promptMessage = "You have finish level 1";

           // pUpDialog.SetActive(true); //if there's no heart then you cannot proceed/play
            //prmpt.text = promptMessage;
        }

    }

    IEnumerator WTProceed()
    {
        yield return new WaitForSeconds(2f);
        prcd(questions[ind]);
    }
}
