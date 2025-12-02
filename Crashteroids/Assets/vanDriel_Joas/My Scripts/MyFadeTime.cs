using UnityEngine;

public class MyFadeTime : MonoBehaviour
{
    public float fadeTime;

    void Update()
    {
        fadeTime -= Time.deltaTime;

        if (fadeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
