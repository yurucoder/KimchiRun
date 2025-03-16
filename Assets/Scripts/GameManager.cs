using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Intro,
    Playing,
    Dead
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState gameState = GameState.Intro;
    public int lives = 3;
    public float playStartTime;

    [Header("References")]
    public GameObject introUI;
    public GameObject deadUI;
    public GameObject enemySpawner;
    public GameObject foodSpawner;
    public GameObject goldenSpawner;
    public Player player;
    public TMP_Text scoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        introUI.SetActive(true);
    }

    private void Update()
    {
        if (gameState == GameState.Playing)
        {
            scoreText.text = "Score: " + Mathf.FloorToInt(CalculateScore());
        }
        else if (gameState == GameState.Dead)
        {
            scoreText.text = "High Score: " + GetHighScore();
        }
        if (gameState == GameState.Intro && Input.GetKeyDown(KeyCode.Space))
        {
            introUI.SetActive(false);
            enemySpawner.SetActive(true);
            foodSpawner.SetActive(true);
            goldenSpawner.SetActive(true);
            gameState = GameState.Playing;
            playStartTime = Time.time;
        }
        if (gameState == GameState.Playing && lives <= 0)
        {
            player.KillPlayer();
            SaveHighScore();
            enemySpawner.SetActive(false);
            foodSpawner.SetActive(false);
            goldenSpawner.SetActive(false);
            deadUI.SetActive(true);
            gameState = GameState.Dead;
        }
        if (gameState == GameState.Dead && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("main");
        }
    }

    public float CalculateGameSpeed()
    {
        if (gameState != GameState.Playing)
        {
            return 5f;
        }
        float speed = 8f + (0.5f * Mathf.Floor(CalculateScore() / 10));
        return Mathf.Min(speed, 20f);
    }

    private float CalculateScore()
    {
        return Time.time - playStartTime;
    }

    private int GetHighScore()
    {
        return PlayerPrefs.GetInt("highScore");
    }

    private void SaveHighScore()
    {
        int score = Mathf.FloorToInt(CalculateScore());
        int currentHighScore = PlayerPrefs.GetInt("highScore");
        if (score > currentHighScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.Save();
        }
    }
}
