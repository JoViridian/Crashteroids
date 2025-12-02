using UnityEngine;

[CreateAssetMenu(fileName = "HighscoreScript", menuName = "Scriptable Objects/HighscoreScript")]
public class HighscoreScript : ScriptableObject
{
    public int highscore;

    // allows highscore to be recalled in a future play session
    void Awake()
    {
        highscore = PlayerPrefs.GetInt("Highscore");
    }
}
