using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyPause : MonoBehaviour
{
    public GameObject pauseMenu;
    public TextMeshProUGUI pauseText;
    private bool paused;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(GameManagerAltered.Instance.script.keyPause))
        {
            DoPause();
        }

        if (paused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameManagerAltered.Instance.DoHighscoreCheck();
                SceneManager.LoadScene("MainMenu");
            }
        }
        else
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }

        pauseText.text = "\n \n PRESS " + GameManagerAltered.Instance.script.pauseName + " TO RESUME \n \n PRESS <color=#b9cdcdff>escape</color=b9cdcdff> TO QUIT";
    }

    private void DoPause()
    {
        paused = !paused;
    }
}
