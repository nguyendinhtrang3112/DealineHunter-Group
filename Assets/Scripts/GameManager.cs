using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;  
public class GameManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverUi;
    private bool isGameOver = false;
    void Start()
    {
        UpdateScore();
        gameOverUi.SetActive(false);   
    }

    void Update()
    {
        // Để trống cũng được
    }

    public void AddScore(int points)
    {
        if (!isGameOver)
        {
            score += points;
            UpdateScore();
        }
    }

    private void UpdateScore()
    {
        // Kiểm tra xem đã kéo Text vào chưa để tránh lỗi
        if (scoreText != null)
        {
            scoreText.text =score.ToString();
        }
    }
    public void GameOver()
    {
        isGameOver = true;
        score =0;
        Time.timeScale = 0;
        gameOverUi.SetActive(true);
    }
    public void RestartGame()
    {
        isGameOver = false;
        score = 0;
        UpdateScore();
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }
}