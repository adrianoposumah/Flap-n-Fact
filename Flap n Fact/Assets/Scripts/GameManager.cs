using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Tambahkan referensi ke UI Score
    public GameObject GOUI;
    public TextMeshProUGUI finalScoreText;
    public GameObject[] UIObjects;
    private int score;

    private void Start()
    {
        UpdateScoreUI();
    }

    public void HideAllUIObjects()
    {
        foreach (GameObject uiObject in UIObjects)
        {
            uiObject.SetActive(false);
        }
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScoreUI();
    }

    public void GameOver()
    {
        //Debug.Log("Game Over! Final Score: " + score);
        Time.timeScale = 0f;
        GOUI.SetActive(true);
        HideAllUIObjects();
        finalScoreText.text = "" + score;
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "" + score;
    }
}
