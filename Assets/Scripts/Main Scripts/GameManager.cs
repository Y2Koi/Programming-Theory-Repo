using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;
    [SerializeField] TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    [SerializeField] Button restartButton;
    [SerializeField] Button exitButton;
    public static GameManager Instance; // Singleton instance

    private int score = 0;
    public int Score
    {
        get { return score; }
        set
        {
            if (value < 0)
            {
                score = 0;
            }
            else
            {
                score = value;
            }
        }
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject); // Ensure only one instance exists
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        PlayerPrefs.SetInt("HighScore", 0); //USE THIS TO TEST HIGH SCORE!
        UpdateHighScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOver = true;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ReturnToTitle()
    {
        SceneManager.LoadScene("Title Screen");
    }

    public void checkHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = $"High Score: {PlayerPrefs.GetInt("HighScore", 0)}";
    }
}