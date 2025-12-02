using UnityEngine;

public class MyPowerUp : MonoBehaviour
{
    public AudioClip pickupSound;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<MyHP>().hp < 100)
            {
                collision.gameObject.GetComponent<MyHP>().hp++;
            }

            GameManager.Instance.score += 10;
            AudioManager.Instance.PlayClip(pickupSound);
            Destroy(gameObject);
        }
    } 
}
