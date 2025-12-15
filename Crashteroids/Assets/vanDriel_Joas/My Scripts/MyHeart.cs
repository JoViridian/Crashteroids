using UnityEngine;

public class MyHeart : MonoBehaviour
{
    public MyHP hp;
    public SpriteRenderer SpriteRenderer;
    private int hpState;
    public Color color1;
    public Color color2;
    public Color color3;
    public Color color4;
    public Color color5;

    // Update is called once per frame
    void Update()
    {
        hpState = Mathf.FloorToInt((hp.hp - 1) / 20);
        Debug.Log(hpState);

        switch(hpState)
        {
            case 0: SpriteRenderer.color = color5; break;
            case 1: SpriteRenderer.color = color4; break;
            case 2: SpriteRenderer.color = color3; break;
            case 3: SpriteRenderer.color = color2; break;
            case 4: SpriteRenderer.color = color1; break;
        }
    }
}
