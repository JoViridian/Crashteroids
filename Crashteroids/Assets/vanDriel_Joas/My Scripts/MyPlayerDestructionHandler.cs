using UnityEngine;

public class MyPlayerDestructionHandler : MonoBehaviour
{
    public AudioClip gameStartClip;

    void Start()
    {
        AudioManager.Instance.PlayClip(gameStartClip);
    }

    public void DestroyResult()
    {
        GameManagerAltered.finalScore = GameManagerAltered.Instance.score;
        GameManagerAltered.playerState = false;
    }
}
