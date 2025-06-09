using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

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
        string sceneCategory = SceneManager.GetActiveScene().name;

        Question[] allQuestions = new Question[]
        {
            // Addition questions
            new Question { QuestionID = 1, QuestionText = "5 + 3 = 8?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 2, QuestionText = "7 + 4 = 12?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = false },
            new Question { QuestionID = 3, QuestionText = "9 + 6 = 15?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 4, QuestionText = "8 + 2 = 11?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = false },
            new Question { QuestionID = 5, QuestionText = "3 + 7 = 10?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 6, QuestionText = "12 + 5 = 16?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = false },
            new Question { QuestionID = 7, QuestionText = "4 + 9 = 13?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 8, QuestionText = "6 + 8 = 15?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = false },
            new Question { QuestionID = 9, QuestionText = "11 + 3 = 14?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 10, QuestionText = "2 + 9 = 12?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = false },

            // Subtraction questions
            new Question { QuestionID = 11, QuestionText = "10 - 4 = 6?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 12, QuestionText = "15 - 7 = 9?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = false },
            new Question { QuestionID = 13, QuestionText = "12 - 5 = 7?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 14, QuestionText = "20 - 8 = 11?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = false },
            new Question { QuestionID = 15, QuestionText = "18 - 9 = 9?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 16, QuestionText = "14 - 6 = 7?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = false },
            new Question { QuestionID = 17, QuestionText = "16 - 8 = 8?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 18, QuestionText = "13 - 4 = 8?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = false },
            new Question { QuestionID = 19, QuestionText = "11 - 3 = 8?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 20, QuestionText = "17 - 9 = 7?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = false },

            // Multiplication questions
            new Question { QuestionID = 21, QuestionText = "6 × 7 = 42?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 22, QuestionText = "4 × 8 = 30?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = false },
            new Question { QuestionID = 23, QuestionText = "3 × 9 = 27?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 24, QuestionText = "5 × 6 = 35?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = false },
            new Question { QuestionID = 25, QuestionText = "7 × 8 = 56?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 26, QuestionText = "9 × 4 = 35?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = false },
            new Question { QuestionID = 27, QuestionText = "2 × 12 = 24?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 28, QuestionText = "8 × 3 = 25?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = false },
            new Question { QuestionID = 29, QuestionText = "6 × 6 = 36?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 30, QuestionText = "7 × 5 = 40?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = false },

            // Division questions
            new Question { QuestionID = 31, QuestionText = "12 ÷ 4 = 3?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 32, QuestionText = "15 ÷ 3 = 4?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = false },
            new Question { QuestionID = 33, QuestionText = "18 ÷ 6 = 3?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 34, QuestionText = "20 ÷ 4 = 6?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = false },
            new Question { QuestionID = 35, QuestionText = "24 ÷ 8 = 3?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 36, QuestionText = "21 ÷ 7 = 4?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = false },
            new Question { QuestionID = 37, QuestionText = "16 ÷ 4 = 4?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 38, QuestionText = "30 ÷ 6 = 6?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = false },
            new Question { QuestionID = 39, QuestionText = "28 ÷ 7 = 4?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 40, QuestionText = "35 ÷ 5 = 8?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = false },

            // Mixed operations
            new Question { QuestionID = 41, QuestionText = "5 × 2 + 3 = 13?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 42, QuestionText = "10 - 3 × 2 = 4?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 43, QuestionText = "8 + 12 ÷ 4 = 11?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 44, QuestionText = "6 × 3 - 5 = 12?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = false },
            new Question { QuestionID = 45, QuestionText = "15 ÷ 3 + 7 = 12?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 46, QuestionText = "4 + 6 × 2 = 20?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = false },
            new Question { QuestionID = 47, QuestionText = "9 - 4 + 3 = 8?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 48, QuestionText = "7 × 2 - 6 = 9?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = false },
            new Question { QuestionID = 49, QuestionText = "18 ÷ 2 - 4 = 5?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 50, QuestionText = "3 + 5 × 3 = 24?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = false },

            // Additional questions
            new Question { QuestionID = 51, QuestionText = "100 - 25 = 75?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 52, QuestionText = "50 + 30 = 90?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = false },
            new Question { QuestionID = 53, QuestionText = "8 × 12 = 96?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },
            new Question { QuestionID = 54, QuestionText = "72 ÷ 9 = 9?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = false },
            new Question { QuestionID = 55, QuestionText = "45 ÷ 5 = 9?", OptionTrue = "True", OptionFalse = "False", Category ="Matematika", CorrectAnswer = true },

            // Sejarah questions
            new Question { QuestionID = 56, QuestionText = "Proklamasi Kemerdekaan Indonesia terjadi pada tahun 1945?", OptionTrue = "True", OptionFalse = "False", Category ="Sejarah", CorrectAnswer = true },
            new Question { QuestionID = 57, QuestionText = "Soekarno adalah presiden pertama Indonesia?", OptionTrue = "True", OptionFalse = "False", Category ="Sejarah", CorrectAnswer = true },
            new Question { QuestionID = 58, QuestionText = "Candi Borobudur terletak di Sumatera?", OptionTrue = "True", OptionFalse = "False", Category ="Sejarah", CorrectAnswer = false },
            new Question { QuestionID = 59, QuestionText = "VOC adalah perusahaan dagang Belanda?", OptionTrue = "True", OptionFalse = "False", Category ="Sejarah", CorrectAnswer = true },
            new Question { QuestionID = 60, QuestionText = "Perang Diponegoro terjadi pada abad ke-20?", OptionTrue = "True", OptionFalse = "False", Category ="Sejarah", CorrectAnswer = false },
            new Question { QuestionID = 61, QuestionText = "R.A. Kartini dikenal sebagai pahlawan emansipasi wanita?", OptionTrue = "True", OptionFalse = "False", Category ="Sejarah", CorrectAnswer = true },
            new Question { QuestionID = 62, QuestionText = "Sumpah Pemuda diikrarkan pada tahun 1928?", OptionTrue = "True", OptionFalse = "False", Category ="Sejarah", CorrectAnswer = true },
            new Question { QuestionID = 63, QuestionText = "Kerajaan Majapahit berasal dari Kalimantan?", OptionTrue = "True", OptionFalse = "False", Category ="Sejarah", CorrectAnswer = false },
            new Question { QuestionID = 64, QuestionText = "Pangeran Diponegoro berasal dari Yogyakarta?", OptionTrue = "True", OptionFalse = "False", Category ="Sejarah", CorrectAnswer = true },
            new Question { QuestionID = 65, QuestionText = "Hari Pahlawan diperingati setiap 10 November?", OptionTrue = "True", OptionFalse = "False", Category ="Sejarah", CorrectAnswer = true },
            new Question { QuestionID = 66, QuestionText = "Kerajaan Sriwijaya terkenal di bidang pelayaran?", OptionTrue = "True", OptionFalse = "False", Category ="Sejarah", CorrectAnswer = true },
            new Question { QuestionID = 67, QuestionText = "Gajah Mada adalah tokoh dari Kerajaan Mataram?", OptionTrue = "True", OptionFalse = "False", Category ="Sejarah", CorrectAnswer = false },
            new Question { QuestionID = 68, QuestionText = "Peristiwa G30S/PKI terjadi pada tahun 1965?", OptionTrue = "True", OptionFalse = "False", Category ="Sejarah", CorrectAnswer = true },
            new Question { QuestionID = 69, QuestionText = "Budi Utomo berdiri pada tahun 1908?", OptionTrue = "True", OptionFalse = "False", Category ="Sejarah", CorrectAnswer = true },
            new Question { QuestionID = 70, QuestionText = "Ir. Soekarno lahir di Surabaya?", OptionTrue = "True", OptionFalse = "False", Category ="Sejarah", CorrectAnswer = false },
            new Question { QuestionID = 71, QuestionText = "Perang Dunia II berakhir pada tahun 1945?", OptionTrue = "True", OptionFalse = "False", Category ="Sejarah", CorrectAnswer = true },
            new Question { QuestionID = 72, QuestionText = "Kerajaan Kutai adalah kerajaan Hindu tertua di Indonesia?", OptionTrue = "True", OptionFalse = "False", Category ="Sejarah", CorrectAnswer = true },
            new Question { QuestionID = 73, QuestionText = "Pahlawan Pattimura berasal dari Maluku?", OptionTrue = "True", OptionFalse = "False", Category ="Sejarah", CorrectAnswer = true },
            new Question { QuestionID = 74, QuestionText = "Peristiwa Bandung Lautan Api terjadi pada tahun 1946?", OptionTrue = "True", OptionFalse = "False", Category ="Sejarah", CorrectAnswer = true },
            new Question { QuestionID = 75, QuestionText = "Kerajaan Singasari terletak di Jawa Barat?", OptionTrue = "True", OptionFalse = "False", Category ="Sejarah", CorrectAnswer = false },
            new Question { QuestionID = 76, QuestionText = "Pangeran Antasari adalah pahlawan dari Kalimantan?", OptionTrue = "True", OptionFalse = "False", Category ="Sejarah", CorrectAnswer = true },
            new Question { QuestionID = 77, QuestionText = "Rengasdengklok adalah tempat penculikan Soekarno-Hatta?", OptionTrue = "True", OptionFalse = "False", Category ="Sejarah", CorrectAnswer = true },
            new Question { QuestionID = 78, QuestionText = "Perang Padri terjadi di Sumatera Barat?", OptionTrue = "True", OptionFalse = "False", Category ="Sejarah", CorrectAnswer = true },
            new Question { QuestionID = 79, QuestionText = "Sultan Agung adalah raja dari Kerajaan Demak?", OptionTrue = "True", OptionFalse = "False", Category ="Sejarah", CorrectAnswer = false },
            new Question { QuestionID = 80, QuestionText = "Pangeran Samudra adalah pendiri Kerajaan Banjar?", OptionTrue = "True", OptionFalse = "False", Category ="Sejarah", CorrectAnswer = true },

            // BahasaInggris questions
            new Question { QuestionID = 81, QuestionText = "The color of the sky is blue?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = true },
            new Question { QuestionID = 82, QuestionText = "Cat means kucing in Indonesian?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = true },
            new Question { QuestionID = 83, QuestionText = "Apple is a kind of vegetable?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = false },
            new Question { QuestionID = 84, QuestionText = "Monday comes after Sunday?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = false },
            new Question { QuestionID = 85, QuestionText = "Dog means anjing in Indonesian?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = true },
            new Question { QuestionID = 86, QuestionText = "Banana is yellow?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = true },
            new Question { QuestionID = 87, QuestionText = "Fish can fly?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = false },
            new Question { QuestionID = 88, QuestionText = "Bird means burung in Indonesian?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = true },
            new Question { QuestionID = 89, QuestionText = "Sun rises in the west?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = false },
            new Question { QuestionID = 90, QuestionText = "Water is wet?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = true },
            new Question { QuestionID = 91, QuestionText = "Chair means meja in Indonesian?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = false },
            new Question { QuestionID = 92, QuestionText = "Book means buku in Indonesian?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = true },
            new Question { QuestionID = 93, QuestionText = "Tree is bigger than a leaf?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = true },
            new Question { QuestionID = 94, QuestionText = "Red is a color?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = true },
            new Question { QuestionID = 95, QuestionText = "Car is a kind of animal?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = false },
            new Question { QuestionID = 96, QuestionText = "Mother means ibu in Indonesian?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = true },
            new Question { QuestionID = 97, QuestionText = "Father means ayah in Indonesian?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = true },
            new Question { QuestionID = 98, QuestionText = "Pen is used for writing?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = true },
            new Question { QuestionID = 99, QuestionText = "Fish lives on land?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = false },
            new Question { QuestionID = 100, QuestionText = "Table means kursi in Indonesian?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = false },
            new Question { QuestionID = 101, QuestionText = "Sun is hot?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = true },
            new Question { QuestionID = 102, QuestionText = "Ice is cold?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = true },
            new Question { QuestionID = 103, QuestionText = "Dog can swim?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = true },
            new Question { QuestionID = 104, QuestionText = "Cat can bark?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = false },
            new Question { QuestionID = 105, QuestionText = "Apple is red or green?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = true },
            new Question { QuestionID = 106, QuestionText = "Birds have wings?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = true },
            new Question { QuestionID = 107, QuestionText = "Fish can walk?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = false },
            new Question { QuestionID = 108, QuestionText = "Banana is a fruit?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = true },
            new Question { QuestionID = 109, QuestionText = "Book is for eating?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = false },
            new Question { QuestionID = 110, QuestionText = "Dog has four legs?", OptionTrue = "True", OptionFalse = "False", Category ="BahasaInggris", CorrectAnswer = true },
        };

        questions = System.Array.FindAll(allQuestions, q => q.Category == sceneCategory);
        if (questions.Length == 0)
        {
            Debug.LogError("Tidak ada pertanyaan untuk kategori: " + sceneCategory);
            return;
        }
    }

    public void SetNextQuestion()
    {
        if (questions == null || questions.Length == 0)
        {
            questionText.text = "Tidak ada pertanyaan tersedia.";
            optionAText.text = "";
            optionBText.text = "";
            return;
        }
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
    public string Category; 
}
