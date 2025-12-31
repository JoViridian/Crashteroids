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
    public TextMeshProUGUI scoreAdderTextBox;
    public TextMeshProUGUI hpTextBox;
    public MyHP playerHp;
    public AudioClip gameEndClip;
    public GameObject background;
    public HighscoreScript script;

    // static is not neccesary here, but too lazy to change formatting in all other scripts
    public int score;
    public static int finalScore;
    public static int scoreGain;
    public float scoreMultiplier;
    public float scoreTimer;
    public float scoreTimerReset;
    public static float gameOverDelay;
    public static bool playerState;
    public static bool gameStart;
    public static bool highscoreGet;

    public float asteroidSpeed;
    private int difficultyScoreCap = 20000;
    private float difficultyIncreaseSpeed = 0.0002f;
    private float minSpeed = 3;
    private float maxSpeed = 7;
    public float cometOpportunity;

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
        scoreMultiplier = 1;
        scoreTimer = 0;
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
            hpTextBox.text = "" + playerHp.hp.ToString() + "%";
            scoreTextBox.text = scoreGain.ToString();
            DoScoreAddition();
        }
        else
        {
            gameOverDelay -= Time.deltaTime;
            hpTextBox.text = "0%";
            scoreTextBox.text = finalScore.ToString();
            scoreAdderTextBox.text = "";
            DoHighscoreCheck();
        }

        if (gameOverDelay < 0)
        {
            SceneManager.LoadScene("GameOver");
            AudioManagerAltered.Instance.PlayClip(gameEndClip, 1f);
        }
    }

    public void DoHighscoreCheck()
    {
        if (finalScore > script.highscore)
        {
            highscoreGet = true;
            script.highscore = finalScore;
        }
    }

    private void DoScoreAddition()
    {
        if (scoreGain >= score)
        {
            scoreGain = score;  
            scoreAdderTextBox.text = "";
        }
        else
        {
            if (scoreTimer <= 0)
            {
                scoreGain += ((score - scoreGain) / 10) + 1;
            }

            scoreAdderTextBox.text = "+ " + (score - scoreGain).ToString();
        }

        scoreTimer -= Time.deltaTime;
    }
}
