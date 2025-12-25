using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuAltered : MonoBehaviour
{
    public string levelName;
    public bool gamePlayed;
    public TextMeshProUGUI finalScoreTextBox;
    public HighscoreScript script;
    // stands for Highlight Color Start and End
    private string hCs = "<color=#5ef965ff>";
    private string hCe = "</color =#5ef965ff>";

    private void Start()
    {
        finalScoreTextBox.text = "FINAL SCORE: " + hCs + GameManagerAltered.finalScore.ToString() + hCe;

        // repurposes the scene into the start screen if the normal scene has not been loaded yet this play session
        if (gamePlayed == true)
        {
            DoScoreUpdate();
        }
        else
        {
            finalScoreTextBox.text = "\n \n HIGH SCORE: " + hCs + script.highscore.ToString() + hCe;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(levelName);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("Controls");
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
            finalScoreTextBox.text = "FINAL SCORE: " + hCs + GameManagerAltered.finalScore.ToString() + hCe + "\n \n <color=#6af3c0ff>NEW HIGH SCORE:</color=#6af3c0ff> " + hCs + script.highscore.ToString() + hCe;
            PlayerPrefs.SetInt("Highscore", script.highscore);
        }
        else
        {
            finalScoreTextBox.text = "FINAL SCORE: " + hCs + GameManagerAltered.finalScore.ToString() + hCe + "\n \n HIGH SCORE: " + hCs + script.highscore.ToString() + hCe;
        }
    }
}
