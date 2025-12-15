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
            if (collision.gameObject.GetComponent<MyHP>().hp < collision.gameObject.GetComponent<MyHP>().hpMax)
            {
                collision.gameObject.GetComponent<MyHP>().hp++;
            }

            GameManagerAltered.Instance.score += value;
            AudioManagerAltered.Instance.PlayClip(pickupSound, 0.5f);
            Instantiate(effectHit, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    } 
}
