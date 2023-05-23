using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class checkAnswer : MonoBehaviour
{

    public GameObject enemyHeart;
    public GameObject catHeart;
    public GameObject popUpDialog;
    public Text question, textA,textB,textC,textD, prompt;
    public GameObject snakeObj;
    public GameObject catObj;
    

    int index = 0;
    String[] answer = { "choiceC", "choiceC", "choiceD", "choiceA", "choiceD", "choiceA", "choiceA", "choiceD", "choiceB", "choiceC" };
    String[] questionnaire = {
        "How are statements terminated in Java?",
        "How do you display output in Java?",
        "What are the two types of comments in Java?",
        "How do you declare a variable in Java?",
        "What is a data type in Java?",
        "What is the difference between int and double data types in Java?",
        "How do you assign a value to a variable in Java?",
        "What is the default value of an uninitialized variable in Java?",
        "How do you convert a string to an integer in Java?"
    };

    String[] choiceA =
    {
        "a) Colon (:)", "a) print()" , "a)	Single-line and multi-line comments" ,
        "a)	define","a)	A type of variable","a)	int is used for whole numbers, while double is used for decimal numbers",
        "a)	assign()","a) null", "a) Integer.toInteger()"

    };

    String[] choiceB =
    {
        "b)	Comma (,)", "b)	display()", "b)	Small and big comments", "b) var", "b)	A type of class",
        "b)	int is used for decimal numbers, while double is used for whole numbers", "b) store()",
        "b)	0","b)	String.toInteger()",

    };
    String[] choiceC =
    {
        "c)	Semicolon (;)", "c)	show()", "c) Red and blue comments", "c) set", "c)	A type of loop",
        "c)	int is used for text strings, while double is used for numbers","c)	set()", "c)	undefined",
        "c)	Integer.parseInt()"
    };

    String[] choiceD =
    {
        "d)	Period (.)", "d) System.out.println()", "d)	Main and sub comments", "d)	type", "d)	A type of function",
        "d)	int and double are the same data type", "d)	= (equals sign)", "d) void", "d) String.parseInt()"
    };

    public void click()
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.name; //get the name of the button has been clicked
        Answer(buttonName);
 
    }

    private void Answer(String buttonName)
    {
        //correct answer
        if (buttonName == answer[index+1])
        {
            catScript cat = catObj.GetComponent<catScript>();
            cat.Move();
            //while the question is answered correctly it will go to the next index of the array of questions
            RemoveHeart(enemyHeart,false); //reduce the heart of enemy

            //change the questions
            StartCoroutine(waitToProceed());
            index++;

        }
        //wrong answer
        else
        {
            snakeScript snake = snakeObj.GetComponent<snakeScript>();
            snake.Move();
            RemoveHeart(catHeart,true); //reduce the heart of cat
        }
            
    }

    private void proceed(String questions)
    {
        question.text = questions; //change the question
        String forA = choiceA[index];
        String forB = choiceB[index];
        String forC = choiceC[index];
        String forD = choiceD[index];
        changeChoices(forA, forB, forC, forD);
    }

    private void changeChoices(string forA, string forB, string forC, string forD)
    {
        // textA,textB,textC,textD
        textA.text = forA;
        textB.text = forB;
        textC.text = forC;
        textD.text = forD;

    }


    //remove a heart from the user/enemy 
    public void RemoveHeart(GameObject heart, bool isCat)
    {
        if (heart.transform.childCount > 1)
        {
            Transform lastHeart = heart.transform.GetChild(heart.transform.childCount - 1);
            Destroy(lastHeart.gameObject);
        }
        //no more lives
        else
        {
            String promptMessage;
            if (isCat)
                promptMessage = "Sorry you died in the battle";
            else
                promptMessage = "You have finish level 1";

            popUpDialog.SetActive(true); //if there's no heart then you cannot proceed/play
            prompt.text = promptMessage;
        }
           
    }

    IEnumerator waitToProceed()
    {
        yield return new WaitForSeconds(2f);
        proceed(questionnaire[index]);
    }
}