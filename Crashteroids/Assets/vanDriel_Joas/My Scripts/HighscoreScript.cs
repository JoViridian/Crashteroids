using UnityEngine;

[CreateAssetMenu(fileName = "HighscoreScript", menuName = "Scriptable Objects/HighscoreScript")]
public class HighscoreScript : ScriptableObject
{
    public int highscore;
    public KeyCode keyForward;
    public KeyCode keyTurnLeft;
    public KeyCode keyTurnRight;
    public KeyCode keyShoot1;
    public KeyCode keyShoot2;
    public KeyCode keyPause;
    public string pauseName;

    // allows highscore to be recalled in a future play session
    void Awake()
    { 
        if (!PlayerPrefs.HasKey("KeyForward"))
        {
            PlayerPrefs.SetInt("Highscore", 0);
            PlayerPrefs.SetInt("KeyForward", (int)KeyCode.W);
            PlayerPrefs.SetInt("KeyTurnLeft", (int)KeyCode.Q);
            PlayerPrefs.SetInt("KeyTurnRight", (int)KeyCode.E);
            PlayerPrefs.SetInt("KeyShoot1", (int)KeyCode.Mouse0);
            PlayerPrefs.SetInt("KeyShoot2", (int)KeyCode.Mouse1);
            PlayerPrefs.SetInt("KeyPause", (int)KeyCode.P);
        }

        highscore = PlayerPrefs.GetInt("Highscore");
        keyForward = (KeyCode)PlayerPrefs.GetInt("KeyForward");
        keyTurnLeft = (KeyCode)PlayerPrefs.GetInt("KeyTurnLeft");
        keyTurnRight = (KeyCode)PlayerPrefs.GetInt("KeyTurnRight");
        keyShoot1 = (KeyCode)PlayerPrefs.GetInt("KeyShoot1");
        keyShoot2 = (KeyCode)PlayerPrefs.GetInt("KeyShoot2");
        keyPause = (KeyCode)PlayerPrefs.GetInt("KeyPause");
    }
}
