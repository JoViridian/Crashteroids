using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuAltered : MonoBehaviour
{
    public string levelName;
    public TextMeshProUGUI finalScoreTextBox;
    public TextMeshProUGUI titleTextBox;
    public TextMeshProUGUI startTextBox;
    public HighscoreScript script;
    public GameObject logo;

    private void Start()
    {
        finalScoreTextBox.text = "FINAL SCORE:" + GameManagerAltered.finalScore.ToString();

        // repurposes the scene into the start screen if the normal scene has not been loaded yet this play session
        if (GameManagerAltered.gameStart == true)
        {
            logo.SetActive(false);
            DoScoreUpdate();
            titleTextBox.text = "GAME OVER";
            startTextBox.text = "PRESS 'SPACE' TO RETRY \n \n PRESS 'ESCAPE' TO CLOSE GAME";
        }
        else
        {
            logo.SetActive(true);
            finalScoreTextBox.text = "\n \n HIGH SCORE:" + script.highscore.ToString();
            titleTextBox.text = "";
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
        if (GameManagerAltered.highscoreGet)
        {
            finalScoreTextBox.text = "FINAL SCORE:" + GameManagerAltered.finalScore.ToString() + "\n \n NEW HIGH SCORE:" + script.highscore.ToString();
            PlayerPrefs.SetInt("Highscore", script.highscore);
        }
        else
        {
            finalScoreTextBox.text = "FINAL SCORE:" + GameManagerAltered.finalScore.ToString() + "\n \n HIGH SCORE:" + script.highscore.ToString();
        }
    }
}
