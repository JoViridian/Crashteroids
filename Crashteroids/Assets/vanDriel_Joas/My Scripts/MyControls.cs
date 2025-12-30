using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyControls : MonoBehaviour
{
    private string moveControlsDisplay;
    private string shootControlsDisplay;
    private string pauseControlDisplay;
    private int moveState;
    private int shootState;
    private int pauseState;
    public TextMeshProUGUI TextBox;
    public HighscoreScript script;
    public AudioClip click;

    void Awake()
    {
        ControlsCheck();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("MainMenu");
            AudioManagerAltered.Instance.PlayClip(click, 0.75f);
        }

        TextBox.text = "Movement: " + moveControlsDisplay + "\n \nShooting: " + shootControlsDisplay + "\n \nPausing: " + pauseControlDisplay;
    }

    public void ChangeControlsMove()
    {
        switch (moveState)
        {
            case 0:
                script.keyForward = KeyCode.W;
                script.keyTurnLeft = KeyCode.Q;
                script.keyTurnRight = KeyCode.E;
                PlayerPrefs.SetInt("KeyForward", (int)KeyCode.W);
                PlayerPrefs.SetInt("KeyTurnLeft", (int)KeyCode.Q);
                PlayerPrefs.SetInt("KeyTurnRight", (int)KeyCode.E);
                moveControlsDisplay = "<color=#b9cdcdff>QWE</color=b9cdcdff>";
                moveState++;
                break;

            case 1:
                script.keyForward = KeyCode.W;
                script.keyTurnLeft = KeyCode.A;
                script.keyTurnRight = KeyCode.D;
                PlayerPrefs.SetInt("KeyForward", (int)KeyCode.W);
                PlayerPrefs.SetInt("KeyTurnLeft", (int)KeyCode.A);
                PlayerPrefs.SetInt("KeyTurnRight", (int)KeyCode.D);
                moveControlsDisplay = "<color=#b9cdcdff>AWD</color=b9cdcdff>";
                moveState++;
                break;

            case 2:
                script.keyForward = KeyCode.UpArrow;
                script.keyTurnLeft = KeyCode.LeftArrow;
                script.keyTurnRight = KeyCode.RightArrow;
                PlayerPrefs.SetInt("KeyForward", (int)KeyCode.UpArrow);
                PlayerPrefs.SetInt("KeyTurnLeft", (int)KeyCode.LeftArrow);
                PlayerPrefs.SetInt("KeyTurnRight", (int)KeyCode.RightArrow);
                moveControlsDisplay = "<color=#b9cdcdff>ARROW KEYS</color=b9cdcdff>";
                moveState = 0;
                break;
        }
    }
    public void ChangeControlsShoot()
    {
        switch (shootState)
        {
            case 0:
                script.keyShoot1 = KeyCode.Mouse0;
                script.keyShoot2 = KeyCode.Mouse1;
                PlayerPrefs.SetInt("KeyShoot1", (int)KeyCode.Mouse0);
                PlayerPrefs.SetInt("KeyShoot2", (int)KeyCode.Mouse1);
                shootControlsDisplay = "<color=#b9cdcdff>MOUSE BUTTONS</color=b9cdcdff>";
                shootState++;
                break;

            case 1:
                script.keyShoot1 = KeyCode.Space;
                script.keyShoot2 = KeyCode.S;
                PlayerPrefs.SetInt("KeyShoot1", (int)KeyCode.Space);
                PlayerPrefs.SetInt("KeyShoot2", (int)KeyCode.S);
                shootControlsDisplay = "<color=#b9cdcdff>SPACE & S</color=b9cdcdff>";
                shootState++;
                break;

            case 2:
                script.keyShoot1 = KeyCode.Space;
                script.keyShoot2 = KeyCode.DownArrow;
                PlayerPrefs.SetInt("KeyShoot1", (int)KeyCode.Space);
                PlayerPrefs.SetInt("KeyShoot2", (int)KeyCode.DownArrow);
                shootControlsDisplay = "<color=#b9cdcdff>SPACE & DOWN ARROW</color=b9cdcdff>";
                shootState = 0;
                break;
        }
    }

    public void ChangeControlsPause()
    {
        switch (pauseState)
        {
            case 0:
                script.keyPause = KeyCode.P;
                PlayerPrefs.SetInt("KeyPause", (int)KeyCode.P);
                pauseControlDisplay = "<color=#b9cdcdff>P</color=b9cdcdff>";
                script.pauseName = "<color=#b9cdcdff>P</color=b9cdcdff>";
                pauseState++;
                break;

            case 1:
                script.keyPause = KeyCode.Tab;
                PlayerPrefs.SetInt("KeyPause", (int)KeyCode.Tab);
                pauseControlDisplay = "<color=#b9cdcdff>TAB</color=b9cdcdff>";
                script.pauseName = "<color=#b9cdcdff>TAB</color=b9cdcdff>";
                pauseState++;
                break;

            case 2:
                script.keyPause = KeyCode.Backspace;
                PlayerPrefs.SetInt("KeyPause", (int)KeyCode.Backspace);
                pauseControlDisplay = "<color=#b9cdcdff>BACKSPACE</color=b9cdcdff>";
                script.pauseName = "<color=#b9cdcdff>BACKSPACE</color=b9cdcdff>";
                pauseState = 0;
                break;
        }
    }

    public void PlayClick()
    {
        AudioManagerAltered.Instance.PlayClip(click, 0.75f);
    }

    private void ControlsCheck()
    {
        if (script.keyTurnLeft == KeyCode.Q)
        {
            moveState = 0;
        }
        else if (script.keyTurnLeft == KeyCode.A)
        {
            moveState = 1;
        }
        else
        {
            moveState = 2;
        }

        if (script.keyShoot2 == KeyCode.Mouse1)
        {
            shootState = 0;
        }
        else if (script.keyShoot2 == KeyCode.S)
        {
            shootState = 1;
        }
        else
        {
            shootState = 2;
        }

        if (script.keyPause == KeyCode.P)
        {
            pauseState = 0;
        }
        else if (script.keyPause == KeyCode.Tab)
        {
            pauseState = 1;
        }
        else
        {
            pauseState = 2;
        }

        ChangeControlsMove();
        ChangeControlsShoot();
        ChangeControlsPause();
    }
}
