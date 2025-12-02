using UnityEngine;

public class MyPowerUp : MonoBehaviour
{
    public AudioClip pickupSound;
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
            AudioManager.Instance.PlayClip(pickupSound);
            Destroy(gameObject);
        }
    } 
}
