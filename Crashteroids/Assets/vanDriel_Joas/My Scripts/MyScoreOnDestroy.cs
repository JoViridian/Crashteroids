using UnityEngine;

public class MyScoreOnDestroy : MonoBehaviour
{
    public GameObject player;
    public int pointWorth = 0;

    public void DoScore()
    { 
        //only allows score to increase if player still alive
        if (player.GetComponent<MyHP>().hp >= 1)
        {
            GameManager.Instance.score += pointWorth;
        }
    }
}
