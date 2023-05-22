using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public QuestionsStage3[] question;
    public static List<QuestionsStage3> unansweredQuestions;
    public QuestionsStage3 currentQuestion;

    [SerializeField]
    private Text factText;

    [SerializeField]
    private float timeBetweenQuestions = 1f;

    private int answeredCorrectCount = 0; // Variable to track the number of correct answers
    private int answeredIncorrectCount = 0; // Variable to track the number of incorrect answers

    public void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = question.ToList<QuestionsStage3>();
        }
        SetCurrentQuestion();
    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        factText.text = currentQuestion.fact;
    }

    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);

        yield return new WaitForSeconds(timeBetweenQuestions);

        if (unansweredQuestions.Count > 0)
        {
            SetCurrentQuestion();
        }
        else
        {
            CheckWinCondition();
        }
    }

    public void UserSelectA()
    {
        if (currentQuestion.isA)
        {
            Debug.Log("Correct!");
            answeredCorrectCount++;
        }
        else
        {
            Debug.Log("Incorrect!");
            answeredIncorrectCount++;
        }
        StartCoroutine(TransitionToNextQuestion());
        CheckWinCondition();
    }

    public void UserSelectB()
    {
        if (currentQuestion.isB)
        {
            Debug.Log("Correct!");
            answeredCorrectCount++;
        }
        else
        {
            Debug.Log("Incorrect!");
            answeredIncorrectCount++;
        }
        StartCoroutine(TransitionToNextQuestion());
        CheckWinCondition();
    }

    public void UserSelectC()
    {
        if (currentQuestion.isC)
        {
            Debug.Log("Correct!");
            answeredCorrectCount++;
        }
        else
        {
            Debug.Log("Incorrect!");
            answeredIncorrectCount++;
        }
        StartCoroutine(TransitionToNextQuestion());
        CheckWinCondition();
    }

    public void UserSelectD()
    {
        if (currentQuestion.isD)
        {
            Debug.Log("Correct!");
            answeredCorrectCount++;
        }
        else
        {
            Debug.Log("Incorrect!");
            answeredIncorrectCount++;
        }
        StartCoroutine(TransitionToNextQuestion());
        CheckWinCondition();
    }

    void CheckWinCondition()
    {
        // All questions have been answered
        // Add your win condition logic here
        if (answeredCorrectCount >= 7)
        {
            Debug.Log("You win!");
            // Perform actions for winning the game
        }
        else if (answeredIncorrectCount == 3)
        {
            Debug.Log("You lose!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // Perform actions for losing the game
        }
    }
}
