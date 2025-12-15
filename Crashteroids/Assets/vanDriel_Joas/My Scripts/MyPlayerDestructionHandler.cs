using UnityEngine;

public class MyPlayerDestructionHandler : MonoBehaviour
{
    public AudioClip gameStartClip;

    void Start()
    {
        AudioManagerAltered.Instance.PlayClip(gameStartClip, 1f);
    }

    public void DestroyResult()
    {
        GameManagerAltered.finalScore = GameManagerAltered.Instance.score;
        GameManagerAltered.playerState = false;
    }
}
