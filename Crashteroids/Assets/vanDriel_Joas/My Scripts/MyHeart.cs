using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class MyHeart : MonoBehaviour
{
    public MyHP hp;
    public SpriteRenderer SpriteRenderer;
    public GameObject smokeEffect;
    public GameObject coreTransform;
    public AudioClip heartbeat;
    private int pulseState;
    private float pulsePanic;
    private float pulseTimer;
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
        pulseState = 3;
        pulseTimer = 5;
    }

    // Update is called once per frame
    void Update()
    {
        hpState = Mathf.FloorToInt((hp.hp - 1) / 20);

        switch(hpState)
        {
            case 0: 
                SpriteRenderer.color = color5;
                DoSmoke();
                DoSmoke();
                pulsePanic = 0.5f;
                break;
            case 1: 
                SpriteRenderer.color = color4;
                pulsePanic = 1.0f;
                DoSmoke();
                break;
            case 2: 
                SpriteRenderer.color = color3;
                pulsePanic = 2.0f;
                break;
            case 3: 
                SpriteRenderer.color = color2;
                pulsePanic = 3.0f;
                break;
            case 4: 
                SpriteRenderer.color = color1;
                pulsePanic = 4.0f;
                break;
        }

        DoHeartbeat();
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

    private void DoHeartbeat()
    {
        if(pulseState == 1)
        {
            coreTransform.transform.localScale *= (1 + Time.deltaTime);
            PulseCheck(1.2f, true);
        }
        else if(pulseState == 2)
        {
            coreTransform.transform.localScale *= (1 - Time.deltaTime);
            PulseCheck(1, false);
        }
        else if (pulseState == 3)
        {
            DoPulseTimer();
        }
    }

    private void PulseCheck(float a, bool b)
    {
        if(b)
        {
            if (coreTransform.transform.localScale.x >= a)
            {
                pulseState++;
            }
        }
        else
        {
            if (coreTransform.transform.localScale.x <= a)
            {
                pulseState++;
            }
        }
    }

    private void DoPulseTimer()
    {
        if (pulseTimer <= 0)
        {
            pulseTimer = pulsePanic;
            pulseState = 1;
            AudioManagerAltered.Instance.PlayClip(heartbeat, (4 + pulsePanic));
        }
        else
        {
            pulseTimer -= Time.deltaTime;
        }
    }
}
