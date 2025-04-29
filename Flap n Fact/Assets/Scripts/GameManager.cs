using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Tambahkan referensi ke UI Score
    private int score;

    private void Start()
    {
        UpdateScoreUI();
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScoreUI();
    }

    public void GameOver()
    {
        Debug.Log("Game Over! Final Score: " + score);
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "" + score;
    }
}
