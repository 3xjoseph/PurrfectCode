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
    public GameObject popUpDialogCat;
    public GameObject popUpDialogSnake;
    public Text question, textA,textB,textC,textD;
    public GameObject snakeObj;
    public GameObject catObj;
    int index = 0;

    int catLives = 3, snakeLives=8;
    String[] answer = { "choiceC", "choiceC", "choiceD", "choiceA", "choiceD", "choiceA", "choiceA", "choiceD", "choiceB", "choiceC" ,"choiceC",
        "choiceA","choiceD","choiceB"," "};
    String[] questionnaire = {
        "How are statements terminated in Java?",
        "How do you display output in Java?",
        "What are the two types of comments in Java?",
        "How do you declare a variable in Java?",
        "What is a data type in Java?",
        "What is the difference between int and double data types in Java?",
        "How do you assign a value to a variable in Java?",
        "What is the default value of an uninitialized variable in Java?",
        "How do you convert a string to an integer in Java?" ,
        "This method is required and you will see it in every Java program",
        "It marks the beginning and the end of a block of code.",
        "It stores single characters surrounded by single quotes.",
        "These types of data can be used to call methods to perform certain operations.",
        " "
    };

    String[] choiceA =
    {
        "a) Colon (:)", "a) print()" , "a)	Single-line and multi-line comments" ,
        "a)	define","a)	A type of variable","a)	int is used for whole numbers, while double is used for decimal numbers",
        "a)	assign()","a) null", "a) Integer.toInteger()",
        "a) public()",
        "a) { }",
        "a) String",
        "a) Primitive data types", 
        " "

    };

    String[] choiceB =
    {
        "b)	Comma (,)", "b)	display()", "b)	Small and big comments", "b) var", "b)	A type of class",
        "b)	int is used for decimal numbers, while double is used for whole numbers", "b) store()",
        "b)	0","b)	String.toInteger()" ,
        "b) void()",
        "b) ( )",
        "b) Float",
        "b) Non-Primitive data types",
        " "

    };
    String[] choiceC =
    {
        "c)	Semicolon (;)", "c)	show()", "c) Red and blue comments", "c) set", "c)	A type of loop",
        "c)	int is used for text strings, while double is used for numbers","c)	set()", "c)	undefined",
        "c)	Integer.parseInt()" ,
        "c) main()",
        "c) /* */",
        "c) Boolean",
        "c) Primary data types",
        " "
    };

    String[] choiceD =
    {
        "d)	Period (.)", "d) System.out.println()", "d)	Main and sub comments", "d)	type", "d)	A type of function",
        "d)	int and double are the same data type", "d)	= (equals sign)", "d) void", "d) String.parseInt()",
        "d) String()",
        "d) [ ]",
        "d) char",
        "d) Secondary data types",   
        " "
    };

    public void click()
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.name; //get the name of the button has been clicked
        Answer(buttonName); //check if the answer is correct or not
 
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
        changeChoices(forA, forB, forC, forD); //change the choices
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
        if (heart.transform.childCount >= 1)
        {
            Transform lastHeart = heart.transform.GetChild(heart.transform.childCount - 1);
            Destroy(lastHeart.gameObject);

            //remove cat's heart
            if (isCat)
            {
                catLives--;
                if (catLives == 0)
                    StartCoroutine(waitToPopUp(popUpDialogCat)); //show the dialog afte 5 seconds

            }

            //remove snake's heart
            else
            {
                snakeLives--;
                if (snakeLives == 0)
                {
                    //add death animation for snake after loosing
                    snakeScript snake = snakeObj.GetComponent<snakeScript>();
                    snake.Death();
                    StartCoroutine(waitToPopUp(popUpDialogSnake)); //show the dialog afte 5 seconds
                }
                
            }
    
        }
           
    }

    //next question will appear after 4seconds
    IEnumerator waitToProceed()
    {
        yield return new WaitForSeconds(4f);
        proceed(questionnaire[index]);
    }

    //pop up dialog
    IEnumerator waitToPopUp(GameObject popUp)
    {
        yield return new WaitForSeconds(5f);
        popUp.SetActive(true);
    }
}
