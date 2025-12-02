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
            GameManager.finalScore = GameManager.Instance.score;
            GameManager.playerState = false;
    }
}
