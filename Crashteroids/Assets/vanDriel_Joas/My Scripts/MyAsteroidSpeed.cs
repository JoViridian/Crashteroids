using UnityEngine;

public class MyAsteroidSpeed : MonoBehaviour
{
    public float speedBuffer;
    public bool spawnRandomRot;
    private Rigidbody rb;

    private void Start()
    {
        if (spawnRandomRot)
        {
            transform.rotation = Quaternion.Euler(0, Random.value * 360, 0);
        }
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // compares the total velocity of the GO and slowly speeds it up if it is below the set minimum
        if (rb.linearVelocity.magnitude < GameManagerAltered.Instance.asteroidSpeed * speedBuffer)
        {
            rb.linearVelocity *= (1 + Time.deltaTime);
        }
        else if (rb.linearVelocity.magnitude > GameManagerAltered.Instance.asteroidSpeed * speedBuffer * 1.5f)
        {
            rb.linearVelocity *= (1 - Time.deltaTime);
        }
    }
}
