using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerAltered : MonoBehaviour
{
    // GM's singleton for easy access throughout the whole project
    private static GameManagerAltered instance;
    public static GameManagerAltered Instance { get { return instance; } }

    public List<GameObject> asteroidTotal = new List<GameObject>();
    public TextMeshProUGUI scoreTextBox;
    public TextMeshProUGUI hpTextBox;
    public GameObject player;
    public AudioClip gameEndClip;
    public HighscoreScript script;

    // static is not neccesary here, but too lazy to change formatting in all other scripts
    public int score;
    public static int finalScore;
    public static float gameOverDelay;
    public static bool playerState;
    public static bool gameStart;
    public static bool highscoreGet;

    public float asteroidSpeed;
    private int difficultyScoreCap = 20000;
    private float difficultyIncreaseSpeed = 0.0002f;
    private float minSpeed = 3;
    private float maxSpeed = 7;

    private void Awake()
    {
        // setup singleton
        if (instance != null)
            Destroy(instance.gameObject);
        instance = this;
    }

    private void Start()
    {
        gameStart = true;
        playerState = true;
        highscoreGet = false;

        score = 0;
        gameOverDelay = 1;
        asteroidSpeed = 1.2f;
    }

    private void Update()
    {
        // increases obstacle minimum speed in accordance to a player's score, up to a cap
        if (score < difficultyScoreCap)
        {
            asteroidSpeed = minSpeed + difficultyIncreaseSpeed * score;
        }
        else
        {
            asteroidSpeed = maxSpeed;
        }

        if (playerState)
        {
            hpTextBox.text = "HP: " + player.GetComponent<MyHP>().hp.ToString() + "%";
            scoreTextBox.text = score.ToString();
        }
        else
        {
            gameOverDelay -= Time.deltaTime;
            hpTextBox.text = "HP: 0%";
            scoreTextBox.text = finalScore.ToString();
            DoHighscoreCheck();
        }

        if (gameOverDelay < 0)
        {
            SceneManager.LoadScene("GameOver");
            AudioManager.Instance.PlayClip(gameEndClip);
        }
    }

    private void DoHighscoreCheck()
    {
        if (finalScore > script.highscore)
        {
            highscoreGet = true;
            script.highscore = finalScore;
        }
    }
}
