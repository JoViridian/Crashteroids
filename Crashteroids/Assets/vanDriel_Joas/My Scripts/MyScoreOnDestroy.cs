using UnityEngine;

public class MyScoreOnDestroy : MonoBehaviour
{
    public MyHP MyHP;
    public int pointWorth = 0;

    public void DoScore()
    { 
        //only allows score to increase if player still alive
        if (MyHP.hp >= 1)
        {
            GameManagerAltered.Instance.score += Mathf.RoundToInt(pointWorth * GameManagerAltered.Instance.scoreMultiplier);
            GameManagerAltered.Instance.scoreTimer = GameManagerAltered.Instance.scoreTimerReset;
        }
    }
}
