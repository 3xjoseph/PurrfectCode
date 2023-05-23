using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lvl2Script : MonoBehaviour
{
    public GameObject DukeHeart, MidnightHeart;
    public GameObject Win, Lose, Pause;
    public Text qstn;
    public InputField input;
    public GameObject Midnight, Duke;


    public Texture2D[] questionImages;
    public Image imageComponent;
    private int currentQuestionIndex = 0;
    private int questionIndex = 0;

    private int ind = 0;
    private int catLives = 3;
    private int enemyLives = 3;

    String[] sagot = { "(a+b+c)*3/2", "hi.toUpperCase()", "x>y", "else", "switch(remarks)" };
    String[] questions = {
        "Specify the missing code that will print the sum of all the value of the given variables after getting the product when it is multiplied by 3, and also its quotient when divided by 2. The answer must be 9.",
        "Print the string named hi in all uppercase letters.",
        "Specify the missing code that would output “true” based on the given variables.",
        "Specify the correct code that would print “x is less than 30” if the value of the variable x is 23.",
        "Indicate the missing part that would print “Passed” based on the given remarks while using the switch statement."
    };





    public void Restart()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the current scene again
        SceneManager.LoadScene(currentSceneIndex);
    }





    public void Paus()
    {
        Time.timeScale = 0f; //freezing the game and pausing any ongoing animations, physics, or time-dependent logic
        Pause.SetActive(true);
    }





    public void click()
    {
        string ans = input.text;
        Sagot(ans);
        input.text = null;
    }






    private void Sagot(String ans)
    {
        //correct answer
        if (input.text == sagot[ind])
        {
            //while the question is answered correctly it will go to the next index of the array of questions
            RHeart(DukeHeart, false); //reduce the heart of enemy

            //change the questions
            StartCoroutine(WTProceed());
            ind++;


            currentQuestionIndex = questionIndex;

            // Check if the current question index is within valid range
            if (currentQuestionIndex >= 0 && currentQuestionIndex < questionImages.Length)
            {
                // Assign the corresponding image to the Image component
                Sprite newSprite = Sprite.Create(questionImages[currentQuestionIndex], new Rect(0, 0, questionImages[currentQuestionIndex].width, questionImages[currentQuestionIndex].height), Vector2.one * 10f);
                imageComponent.sprite = newSprite;
            }

            currentQuestionIndex++;
            questionIndex++;
        }

        //wrong answer
        else
        {
            RHeart(MidnightHeart, true); //reduce the heart of cat
        }

    }

    private void prcd(String questions)
    {
        qstn.text = questions; //change the question

    }


    //remove a heart from the user/enemy 
    public void RHeart(GameObject heart, bool isCat)
    {
        if (heart.transform.childCount >= 1)
        {
            Transform lastHeart = heart.transform.GetChild(heart.transform.childCount - 1);
            Destroy(lastHeart.gameObject);

            //remove cat's heart
            if (isCat)
            {
                catLives--;
                if (catLives == 0)
                    Lose.SetActive(true); //show the dialog afte 5 seconds

            }

            //remove snake's heart
            else
            {
                enemyLives--;
                if (enemyLives == 0)
                {
                    //add death animation for snake after loosing
                    Win.SetActive(true); //show the dialog afte 5 seconds
                }

            }

        }
    }

        IEnumerator WTProceed()
        {
            yield return new WaitForSeconds(.1f);
            prcd(questions[ind]);
        }
    }

