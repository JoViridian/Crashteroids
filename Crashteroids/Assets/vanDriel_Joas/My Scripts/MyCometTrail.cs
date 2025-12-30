using UnityEditor;
using UnityEngine;

public class MyCometTrail : MonoBehaviour
{
    private float snowTimerMain;
    public float snowTimerMax;
    public GameObject snowEffect;
    public AudioClip[] snowShimmer = new AudioClip[2];

    void Start()
    {
        snowTimerMain = snowTimerMax;
    }

    void Update()
    {
        if (snowTimerMain < 0)
        {
            Instantiate(snowEffect, transform.position, transform.rotation);
            AudioManagerAltered.Instance.PlayRandomClip(snowShimmer, 0.5f);
            snowTimerMain = snowTimerMax;
        }
        else
        {
            snowTimerMain -= Time.deltaTime;
        }
    }
}
