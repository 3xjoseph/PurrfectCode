using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using static Cinemachine.DocumentationSortingAttribute;

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

    [SerializeField]
    private GameObject losePanel;

    [SerializeField]
    private GameObject winPanel;

    [SerializeField]
    private Button backButton;

    [SerializeField]
    private Button restartButton;

    private int currentHealth = 3; // Assuming the initial health is full (3 hearts)
    public GameObject heartContainer;

    private int enemyHealth = 7; // Assuming the initial health is full (7 hearts)
    public GameObject enemyHeartContainer;

    public void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = question.ToList<QuestionsStage3>();
        }
        SetCurrentQuestion();

        backButton.onClick.AddListener(GoBack);
        restartButton.onClick.AddListener(RestartScene);
    }

    public void GoBack()
    {
        // Load the previous scene (assuming it's the scene with build index 0)
        SceneManager.LoadScene(7);
    }

    public void RestartScene()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
            CorrectAns();
        }
        else
        {
            IncorrectAns();
        }
        
    }

    public void UserSelectB()
    {
        if (currentQuestion.isB)
        {
            CorrectAns();
        }
        else
        {
            IncorrectAns();
        }
        
    }

    public void UserSelectC()
    {
        if (currentQuestion.isC)
        {
            CorrectAns();
        }
        else
        {
            IncorrectAns();
        }
        
    }

    public void UserSelectD()
    {
        if (currentQuestion.isD)
        {
            CorrectAns();
        }
        else
        {
            IncorrectAns();
        }
        
    }

    private void IncorrectAns()
    {
        Debug.Log("Incorrect!");
        answeredIncorrectCount++;

        // Decrease the health by 1
        currentHealth--;

        // Get the index of the heart sprite to hide (assuming 0-indexed)
        int heartIndexToHide = currentHealth;

        // Set the corresponding heart sprite in the hierarchy to inactive
        GameObject heartToHide = heartContainer.transform.GetChild(heartIndexToHide).gameObject;
        heartToHide.SetActive(false);

        StartCoroutine(TransitionToNextQuestion());
        CheckWinCondition();
    }

    private void CorrectAns()
    {
        Debug.Log("Correct!");
        answeredCorrectCount++;

        // Decrease the enemy's health by 1
        enemyHealth--;

        // Get the index of the heart sprite to hide (assuming 0-indexed)
        int heartIndexToHide = enemyHealth - 1;

        // Check if the heart index is within the valid range
        if (heartIndexToHide >= 0 && heartIndexToHide < enemyHeartContainer.transform.childCount)
        {
            // Set the corresponding heart sprite in the hierarchy to inactive
            GameObject heartToHide = enemyHeartContainer.transform.GetChild(heartIndexToHide).gameObject;
            heartToHide.SetActive(false);
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
            winPanel.SetActive(true);
        }
        else if (answeredIncorrectCount == 3)
        {
            Debug.Log("You lose!");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // Perform actions for losing the game
            losePanel.SetActive(true);
        }
    }
}
