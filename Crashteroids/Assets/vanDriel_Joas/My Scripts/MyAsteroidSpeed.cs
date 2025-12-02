using UnityEngine;

public class MyAsteroidSpeed : MonoBehaviour
{
    private float velX;
    private float velZ;
    public float speedBuffer;
    public bool spawnRandomRot;

    private void Start()
    {
        if (spawnRandomRot == true)
        {
            transform.rotation = Quaternion.Euler(0, Random.value * 360, 0);
        }
    }

    void Update()
    {
        velX = Mathf.Abs(gameObject.GetComponent<Rigidbody>().linearVelocity.x);
        velZ = Mathf.Abs(gameObject.GetComponent<Rigidbody>().linearVelocity.z);

        // compares the total velocity of the GO and slowly speeds it up if it is below the set minimum
        if ( velX + velZ < GameManager.Instance.asteroidSpeed * speedBuffer)
        {
            gameObject.GetComponent<Rigidbody>().linearVelocity *= (1 + Time.deltaTime);
        }
    }
}
