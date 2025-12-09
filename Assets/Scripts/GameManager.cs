using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;  
public class GameManager : MonoBehaviour
{
    public GameObject door;
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverUi;
    [SerializeField] private GameObject winUi;
    private bool isGameOver = false;
    private bool isWin = false;
    void Start()
    {
        UpdateScore();
        gameOverUi.SetActive(false);   
        winUi.SetActive(false);
    }
    public void AddScore(int points)
    {
        if (!isGameOver && !isWin)
        {
            score += points;
            UpdateScore();
            if (score >= 8)
            {
                door.SetActive(false);
            }
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
    public void WinGame()
    {
        isWin = true;
        Time.timeScale = 0;
        winUi.SetActive(true);
    }
    public void RestartGame()
    {
        isGameOver = false;
        score = 0;
        UpdateScore();
        Time.timeScale = 1;
        
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(currentIndex);
    }
    public void RestartGame3()
    {
        isGameOver = false;
        score = 0;
        UpdateScore();
        Time.timeScale = 1;
        SceneManager.LoadScene("Level3");
    }
    public void NextLevel2()
    {
        isWin = false;
        score = 0;
        UpdateScore();
        Time.timeScale = 1;
        SceneManager.LoadScene("Level2");
    }
    public void NextLevel3()
    {
        isWin = false;
        score = 0;
        UpdateScore();
        Time.timeScale = 1;
        SceneManager.LoadScene("Level3");
    }
    public void GotoMenu()
    {
        Time.timeScale = 1;
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(currentIndex);
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }
    public bool IsWin()
    {
        return isWin;
    }
}