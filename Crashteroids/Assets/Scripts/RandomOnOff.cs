using UnityEngine;

public class RandomOnOff : MonoBehaviour
{
    public float minWaitTime, maxWaitTime;
    public float minOnTime, maxOnTime;
    public SpriteRenderer sprite;

    private float waitTimer;
    private float onTimer;

    private void Start()
    {
        ResetTimers();
    }

    private void Update()
    {
        // on right now? wait out the flicker timer 
        if (onTimer > 0)
        {
            // decrease timer
            onTimer -= Time.deltaTime;

            // end this flicker if timer ran out
            if (onTimer <= 0)
            {                    
                // disable sprite 
                sprite.enabled = false;
            }    

            // return, since we're not waiting if we're flickering!
            return;
        }

        // decrease wait timer
        waitTimer -= Time.deltaTime;

        // wait out the timer
        if (waitTimer <= 0)
        {
            // set timers again
            ResetTimers();

            // enable sprite
            sprite.enabled = true;
        }
    }

    private void ResetTimers()
    {
        // reset timers to a random time
        waitTimer = Random.Range(minWaitTime, maxWaitTime);
        onTimer = Random.Range(minOnTime, maxOnTime);
    }
}
