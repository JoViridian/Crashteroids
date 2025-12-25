using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyControls : MonoBehaviour
{
    private string moveControlsDisplay;
    private string shootControlsDisplay;
    private int moveState;
    private int shootState;
    public TextMeshProUGUI TextBox;
    public HighscoreScript script;

    void Awake()
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

        ChangeControlsMove();
        ChangeControlsShoot();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("MainMenu");
        }

        TextBox.text = "Movement: " + moveControlsDisplay + "\n \nShooting: " + shootControlsDisplay + "\n \nPausing: <color=#b9cdcdff>P</color=b9cdcdff>";

        Debug.Log(moveState + shootState);
    }
    public void ChangeControlsMove()
    {
        switch (moveState)
        {
            case 0:
                script.keyForward = KeyCode.W;
                script.keyTurnLeft = KeyCode.Q;
                script.keyTurnRight = KeyCode.E;
                moveControlsDisplay = "<color=#b9cdcdff>QWE</color=b9cdcdff>";
                moveState++;
                break;

            case 1:
                script.keyForward = KeyCode.W;
                script.keyTurnLeft = KeyCode.A;
                script.keyTurnRight = KeyCode.D;
                moveControlsDisplay = "<color=#b9cdcdff>AWD</color=b9cdcdff>";
                moveState++;
                break;

            case 2:
                script.keyForward = KeyCode.UpArrow;
                script.keyTurnLeft = KeyCode.LeftArrow;
                script.keyTurnRight = KeyCode.RightArrow;
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
                shootControlsDisplay = "<color=#b9cdcdff>MOUSE BUTTONS</color=b9cdcdff>";
                shootState++;
                break;

            case 1:
                script.keyShoot1 = KeyCode.Space;
                script.keyShoot2 = KeyCode.S;
                shootControlsDisplay = "<color=#b9cdcdff>SPACE & S</color=b9cdcdff>";
                shootState++;
                break;

            case 2:
                script.keyShoot1 = KeyCode.Space;
                script.keyShoot2 = KeyCode.DownArrow;
                shootControlsDisplay = "<color=#b9cdcdff>SPACE & DOWN ARROW</color=b9cdcdff>";
                shootState = 0;
                break;
        }
    }
}
