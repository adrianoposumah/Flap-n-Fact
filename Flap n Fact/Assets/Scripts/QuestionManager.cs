using UnityEngine;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI optionAText;
    public TextMeshProUGUI optionBText;

    private Question[] questions;
    private int currentQuestionIndex;

    private void Start()
    {
        LoadQuestions();
        SetNextQuestion();
    }

    private void LoadQuestions()
    {
        questions = new Question[]
        {
            new Question
            {
                QuestionID = 1,
                QuestionText = "5 + 3 = 8?",
                OptionTrue = "True",
                OptionFalse = "False",
                CorrectAnswer = true
            },
            new Question
            {
                QuestionID = 2,
                QuestionText = "6 × 7 = 42?",
                OptionTrue = "True",
                OptionFalse = "False",
                CorrectAnswer = true
            },
            new Question
            {
                QuestionID = 3,
                QuestionText = "12 ÷ 4 = 5?",
                OptionTrue = "True",
                OptionFalse = "False",
                CorrectAnswer = false
            }
        };
    }

    public void SetNextQuestion()
    {
        currentQuestionIndex = Random.Range(0, questions.Length);
        Question currentQuestion = questions[currentQuestionIndex];

        questionText.text = currentQuestion.QuestionText;
        optionAText.text = currentQuestion.OptionTrue;
        optionBText.text = currentQuestion.OptionFalse;
    }

    public bool IsAnswerCorrect(bool isGreenGem)
    {
        return questions[currentQuestionIndex].CorrectAnswer == isGreenGem;
    }
}

[System.Serializable]
public class Question
{
    public int QuestionID;
    public string QuestionText;
    public string OptionTrue;
    public string OptionFalse;
    public bool CorrectAnswer;
}
