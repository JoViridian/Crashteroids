using UnityEngine;
using UnityEngine.SceneManagement;

public class MyPause : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool paused;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.P))
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
                SceneManager.LoadScene("level1");
            }
        }
        else
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }
    }

    private void DoPause()
    {
        paused = !paused;
    }
}
