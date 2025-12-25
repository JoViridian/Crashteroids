using UnityEngine;

public class MyThruster : MonoBehaviour
{
    public GameObject bulletPrefab;
    public AudioClip[] randomThrusterSound = new AudioClip[3];
    public Vector3 deployDistance;
    private float dropOffset = -0.7f;
    public float dropDelayStart = 0.05f;
    public float dropDelayVariation = 0.03f;
    private float dropDelay;
    public float bulletSpeed = 300;
    private int bulletOffset = 90;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dropDelay = dropDelayStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(GameManagerAltered.Instance.script.keyForward))
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
            AudioManagerAltered.Instance.PlayRandomClip(randomThrusterSound, 0.25f);
        }
        else
        {
            dropDelay -= Time.deltaTime;
        }
    }
}
