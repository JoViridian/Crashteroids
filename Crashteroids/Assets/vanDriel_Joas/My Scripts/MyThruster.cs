using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UIElements;

public class MyThruster : MonoBehaviour
{
    public GameObject bulletPrefab;
    //public AudioClip simpleBoost;
    public Vector3 deployDistance;
    private float dropOffset = -0.5f;
    public float dropDelayStart = 0.15f;
    public float dropDelayVariation = 0.05f;
    private float dropDelay;
    public float bulletSpeed = 300;
    private int bulletOffset = 60;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dropDelay = dropDelayStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            deployDistance = transform.TransformPoint(0, 0, dropOffset);
            DoProjectile(bulletOffset);
        }
    }

    private void DoProjectile(int offset)
    { 
        if (dropDelay <= 0)
        {
            // creates a bullet and then gives that bullet velocity and rotation based on the player's rotation and a given offset
            int rotation = Random.Range(-offset, offset);
            GameObject bulletInstance = Instantiate(bulletPrefab, deployDistance, transform.rotation);
            bulletInstance.gameObject.transform.Rotate(0, 180, 0);
            bulletInstance.GetComponent<Rigidbody>().AddRelativeForce(rotation, 0, -bulletSpeed);

            dropDelay = dropDelayStart + Random.Range(-dropDelayVariation, dropDelayVariation);
        }
        else
        {
            dropDelay -= Time.deltaTime;
        }

        //AudioManager.Instance.PlayClip(simpleBoost);
    }
}
