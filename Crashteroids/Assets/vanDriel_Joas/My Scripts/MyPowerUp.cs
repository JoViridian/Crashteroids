using UnityEngine;

public class MyPowerUp : MonoBehaviour
{
    public AudioClip pickupSound;
    public GameObject effectHit;
    public int value = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<MyHP>().hp += value;
            collision.gameObject.GetComponent<MyHP>().hp = Mathf.Clamp(collision.gameObject.GetComponent<MyHP>().hp, 0, collision.gameObject.GetComponent<MyHP>().hpMax);

            GameManagerAltered.Instance.score += value;
            GameManagerAltered.Instance.cometOpportunity = Random.Range(0f, 100f);
            GameManagerAltered.Instance.scoreTimer = GameManagerAltered.Instance.scoreTimerReset;
            AudioManagerAltered.Instance.PlayClip(pickupSound, 0.5f);
            Instantiate(effectHit, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    } 
}
