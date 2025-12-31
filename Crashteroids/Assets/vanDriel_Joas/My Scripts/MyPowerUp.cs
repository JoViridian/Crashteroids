using UnityEngine;

public class MyPowerUp : MonoBehaviour
{
    public AudioClip pickupSound;
    public GameObject effectHit;
    public bool powerUpState;
    public int value = 10;
    public float multBoost;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<MyHP>().hp += value;
            collision.gameObject.GetComponent<MyHP>().hp = Mathf.Clamp(collision.gameObject.GetComponent<MyHP>().hp, 0, collision.gameObject.GetComponent<MyHP>().hpMax);

            if (powerUpState)
            {
                collision.gameObject.GetComponent<MyRushPowerUp>().rushState = true;
            }

            GameManagerAltered.Instance.score += value;
            GameManagerAltered.Instance.scoreMultiplier += multBoost;
            GameManagerAltered.Instance.cometOpportunity = Random.Range(0f, 100f);
            Debug.Log(GameManagerAltered.Instance.cometOpportunity);
            GameManagerAltered.Instance.scoreTimer = GameManagerAltered.Instance.scoreTimerReset;
            AudioManagerAltered.Instance.PlayClip(pickupSound, 0.5f);
            Instantiate(effectHit, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    } 
}
