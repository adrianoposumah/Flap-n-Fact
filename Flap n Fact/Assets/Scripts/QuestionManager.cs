using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class QuestionManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI optionAText;
    public TextMeshProUGUI optionBText;

    private Question[] questions;
    private int currentQuestionIndex;
    private List<int> usedQuestionIndices = new List<int>();

    private void Start()
    {
        LoadQuestions();
        SetNextQuestion();
    }

    private void LoadQuestions()
    {
        questions = new Question[]
        {
            // Addition questions
            new Question { QuestionID = 1, QuestionText = "5 + 3 = 8?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 2, QuestionText = "7 + 4 = 12?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = false },
            new Question { QuestionID = 3, QuestionText = "9 + 6 = 15?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 4, QuestionText = "8 + 2 = 11?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = false },
            new Question { QuestionID = 5, QuestionText = "3 + 7 = 10?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 6, QuestionText = "12 + 5 = 16?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = false },
            new Question { QuestionID = 7, QuestionText = "4 + 9 = 13?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 8, QuestionText = "6 + 8 = 15?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = false },
            new Question { QuestionID = 9, QuestionText = "11 + 3 = 14?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 10, QuestionText = "2 + 9 = 12?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = false },

            // Subtraction questions
            new Question { QuestionID = 11, QuestionText = "10 - 4 = 6?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 12, QuestionText = "15 - 7 = 9?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = false },
            new Question { QuestionID = 13, QuestionText = "12 - 5 = 7?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 14, QuestionText = "20 - 8 = 11?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = false },
            new Question { QuestionID = 15, QuestionText = "18 - 9 = 9?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 16, QuestionText = "14 - 6 = 7?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = false },
            new Question { QuestionID = 17, QuestionText = "16 - 8 = 8?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 18, QuestionText = "13 - 4 = 8?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = false },
            new Question { QuestionID = 19, QuestionText = "11 - 3 = 8?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 20, QuestionText = "17 - 9 = 7?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = false },

            // Multiplication questions
            new Question { QuestionID = 21, QuestionText = "6 × 7 = 42?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 22, QuestionText = "4 × 8 = 30?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = false },
            new Question { QuestionID = 23, QuestionText = "3 × 9 = 27?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 24, QuestionText = "5 × 6 = 35?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = false },
            new Question { QuestionID = 25, QuestionText = "7 × 8 = 56?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 26, QuestionText = "9 × 4 = 35?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = false },
            new Question { QuestionID = 27, QuestionText = "2 × 12 = 24?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 28, QuestionText = "8 × 3 = 25?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = false },
            new Question { QuestionID = 29, QuestionText = "6 × 6 = 36?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 30, QuestionText = "7 × 5 = 40?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = false },

            // Division questions
            new Question { QuestionID = 31, QuestionText = "12 ÷ 4 = 3?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 32, QuestionText = "15 ÷ 3 = 4?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = false },
            new Question { QuestionID = 33, QuestionText = "18 ÷ 6 = 3?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 34, QuestionText = "20 ÷ 4 = 6?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = false },
            new Question { QuestionID = 35, QuestionText = "24 ÷ 8 = 3?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 36, QuestionText = "21 ÷ 7 = 4?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = false },
            new Question { QuestionID = 37, QuestionText = "16 ÷ 4 = 4?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 38, QuestionText = "30 ÷ 6 = 6?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = false },
            new Question { QuestionID = 39, QuestionText = "28 ÷ 7 = 4?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 40, QuestionText = "35 ÷ 5 = 8?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = false },

            // Mixed operations
            new Question { QuestionID = 41, QuestionText = "5 × 2 + 3 = 13?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 42, QuestionText = "10 - 3 × 2 = 4?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 43, QuestionText = "8 + 12 ÷ 4 = 11?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 44, QuestionText = "6 × 3 - 5 = 12?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = false },
            new Question { QuestionID = 45, QuestionText = "15 ÷ 3 + 7 = 12?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 46, QuestionText = "4 + 6 × 2 = 20?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = false },
            new Question { QuestionID = 47, QuestionText = "9 - 4 + 3 = 8?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 48, QuestionText = "7 × 2 - 6 = 9?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = false },
            new Question { QuestionID = 49, QuestionText = "18 ÷ 2 - 4 = 5?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 50, QuestionText = "3 + 5 × 3 = 24?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = false },

            // Additional questions
            new Question { QuestionID = 51, QuestionText = "100 - 25 = 75?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 52, QuestionText = "50 + 30 = 90?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = false },
            new Question { QuestionID = 53, QuestionText = "8 × 12 = 96?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true },
            new Question { QuestionID = 54, QuestionText = "72 ÷ 9 = 9?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = false },
            new Question { QuestionID = 55, QuestionText = "45 ÷ 5 = 9?", OptionTrue = "True", OptionFalse = "False", CorrectAnswer = true }
        };
    }

    public void SetNextQuestion()
    {
        // Check if all questions have been used
        if (usedQuestionIndices.Count >= questions.Length)
        {
            questionText.text = "Pertanyaan Habis";
            optionAText.text = "";
            optionBText.text = "";
            return;
        }

        // Find an unused question
        int attempts = 0;
        do
        {
            currentQuestionIndex = Random.Range(0, questions.Length);
            attempts++;
            
            // Prevent infinite loop
            if (attempts > 100)
            {
                // Find first unused question
                for (int i = 0; i < questions.Length; i++)
                {
                    if (!usedQuestionIndices.Contains(i))
                    {
                        currentQuestionIndex = i;
                        break;
                    }
                }
                break;
            }
        }
        while (usedQuestionIndices.Contains(currentQuestionIndex));

        // Mark this question as used
        usedQuestionIndices.Add(currentQuestionIndex);

        // Display the question
        Question currentQuestion = questions[currentQuestionIndex];
        questionText.text = currentQuestion.QuestionText;
        optionAText.text = currentQuestion.OptionTrue;
        optionBText.text = currentQuestion.OptionFalse;
    }

    public bool IsAnswerCorrect(bool isGreenGem)
    {
        return questions[currentQuestionIndex].CorrectAnswer == isGreenGem;
    }

    // Optional: Method to reset question pool
    public void ResetQuestionPool()
    {
        usedQuestionIndices.Clear();
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
