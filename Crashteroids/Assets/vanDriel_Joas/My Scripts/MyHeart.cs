using UnityEngine;

public class MyHeart : MonoBehaviour
{
    public MyHP hp;
    public SpriteRenderer SpriteRenderer;
    public GameObject smokeEffect;
    private float smokeTimerMain;
    public float smokeTimerMax;
    private int hpState;
    public Color color1;
    public Color color2;
    public Color color3;
    public Color color4;
    public Color color5;

    void Start()
    {
        smokeTimerMain = smokeTimerMax;
    }

    // Update is called once per frame
    void Update()
    {
        hpState = Mathf.FloorToInt((hp.hp - 1) / 20);
        Debug.Log(hpState);

        switch(hpState)
        {
            case 0: 
                SpriteRenderer.color = color5;
                DoSmoke();
                DoSmoke();
                break;
            case 1: 
                SpriteRenderer.color = color4;
                DoSmoke();
                break;
            case 2: 
                SpriteRenderer.color = color3; 
                break;
            case 3: 
                SpriteRenderer.color = color2; 
                break;
            case 4: 
                SpriteRenderer.color = color1; 
                break;
        }
    }

    private void DoSmoke()
    {
        if (smokeTimerMain < 0)
        {
            Instantiate(smokeEffect, transform.position, transform.rotation);
            smokeTimerMain = smokeTimerMax;
        }
        else
        {
            smokeTimerMain -= Time.deltaTime;
        }
    }
}
