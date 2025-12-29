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
        //keyForward = (KeyCode)PlayerPrefs.GetInt("KeyForward");
    }
}
