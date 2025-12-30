using UnityEngine;

public class MyPlayerDestructionHandler : MonoBehaviour
{
    public AudioClip gameStartClip;

    void Start()
    {
        AudioManagerAltered.Instance.PlayClip(gameStartClip, 0.5f);
    }

    public void DestroyResult()
    {
        GameManagerAltered.finalScore = GameManagerAltered.Instance.score;
        GameManagerAltered.playerState = false;
    }
}
