using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public string levelName;
    public TextMeshProUGUI finalScoreTextBox;
    public TextMeshProUGUI titleTextBox;
    public TextMeshProUGUI startTextBox;
    public HighscoreScript script;

    private void Start()
    {
        finalScoreTextBox.text = "FINAL SCORE:" + GameManager.finalScore.ToString();

        // repurposes the scene into the start screen if the normal scene has not been loaded yet this play session
        if (GameManager.gameStart == true)
        {
            DoScoreUpdate();
            titleTextBox.text = "GAME OVER";
            startTextBox.text = "PRESS 'SPACE' TO RETRY \n \n PRESS 'ESCAPE' TO CLOSE GAME";
        }
        else
        {
            finalScoreTextBox.text = "HIGH SCORE:" + script.highscore.ToString();
            titleTextBox.text = "CRASHTEROIDS";
            startTextBox.text = "PRESS 'SPACE' TO START \n \n PRESS 'ESCAPE' TO CLOSE GAME";
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(levelName);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void DoScoreUpdate()
    {
        // updates the highscore and allows it to be called in a future play session
        if (GameManager.highscoreGet == true)
        {
            finalScoreTextBox.text = "FINAL SCORE:" + GameManager.finalScore.ToString() + "\n \n NEW HIGH SCORE:" + script.highscore.ToString();
            PlayerPrefs.SetInt("Highscore", script.highscore);
        }
        else
        {
            finalScoreTextBox.text = "FINAL SCORE:" + GameManager.finalScore.ToString() + "\n \n HIGH SCORE:" + script.highscore.ToString();
        }
    }
}
