using System.Collections.Generic;
using UnityEngine;

public class MySpawnRandom : MonoBehaviour
{
    public List<Sprite> randomSprite = new List<Sprite>();
    public SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Awake()
    {
        int a = Random.Range(0, randomSprite.Count);
        spriteRenderer.sprite = randomSprite[a];
    }
}
