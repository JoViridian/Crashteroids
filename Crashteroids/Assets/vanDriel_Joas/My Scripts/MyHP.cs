using UnityEngine;
using UnityEngine.Events;

public class MyHP : MonoBehaviour
{
    public int hp;
    public int hpMax = 100;
    public float invincibility;
    private float invincibilityCountdown;
    private int hitTotal;

    public LayerMask hitMask;
    public GameObject effectHit;
    public GameObject effectDeath;
    public AudioClip deathSound;
    public AudioClip hitSound;
    public UnityEvent onDestroy;

    void Start()
    {
        invincibilityCountdown = invincibility;
    }

    void Update()
    {
        invincibilityCountdown -= Time.deltaTime;

        if (hp <= 0)
        {
            Instantiate(effectDeath, transform.position, transform.rotation);
            AudioManagerAltered.Instance.PlayClip(deathSound, 1f);
            onDestroy.Invoke();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // check if objects are supposed to damage eachother
        if (LayerHelper.IsInLayerMask(collision.gameObject, hitMask) && invincibilityCountdown < 0)
        {
            // checks to see how much damage ought to be taken based on the collision and then deals it
            hitTotal = collision.gameObject.GetComponent<MyDamagePower>().DoDamage(gameObject);
            hp -= hitTotal;

            invincibilityCountdown = invincibility;
            Instantiate(effectHit, transform.position, transform.rotation);
            AudioManagerAltered.Instance.PlayClip(hitSound, 1f);
        }
    }
}
