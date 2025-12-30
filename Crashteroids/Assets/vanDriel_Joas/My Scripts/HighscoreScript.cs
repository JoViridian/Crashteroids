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
        highscore = PlayerPrefs.GetInt("Highscore");
        keyForward = (KeyCode)PlayerPrefs.GetInt("KeyForward");
        keyTurnLeft = (KeyCode)PlayerPrefs.GetInt("KeyTurnLeft");
        keyTurnRight = (KeyCode)PlayerPrefs.GetInt("KeyTurnRight");
        keyShoot1 = (KeyCode)PlayerPrefs.GetInt("KeyShoot1");
        keyShoot2 = (KeyCode)PlayerPrefs.GetInt("KeyShoot2");
        keyPause = (KeyCode)PlayerPrefs.GetInt("KeyPause");
    }
}
