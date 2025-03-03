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

    [Header("References")]
    public GameObject introUI;
    public GameObject enemySpawner;
    public GameObject foodSpawner;
    public GameObject goldenSpawner;
    public Player player;

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
        if (gameState == GameState.Intro && Input.GetKeyDown(KeyCode.Space))
        {
            introUI.SetActive(false);
            enemySpawner.SetActive(true);
            foodSpawner.SetActive(true);
            goldenSpawner.SetActive(true);
            gameState = GameState.Playing;
        }
        if (gameState == GameState.Playing && lives <= 0)
        {
            player.KillPlayer();
            enemySpawner.SetActive(false);
            foodSpawner.SetActive(false);
            goldenSpawner.SetActive(false);
            gameState = GameState.Dead;
        }
        if (gameState == GameState.Dead && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("main");
        }
    }
}
