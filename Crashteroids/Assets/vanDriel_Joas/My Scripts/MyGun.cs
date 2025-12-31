using UnityEngine;

public class MyGun : MonoBehaviour
{
    public MyRushPowerUp rush;
    public GameObject bulletPrefab;
    public GameObject bulletPrefabBig;
    public AudioClip simpleBullet;
    public AudioClip[] randomBulletSound = new AudioClip[2];
    public SpriteRenderer cooldownEffect;

    public Vector3 deployDistance;
    private float dropOffset = 0.5f;
    public float bulletSpeed = 300;
    private float bulletSpeedMult = 5;
    private float bulletRotationMult = 0.25f;
    public int bulletOffset = 60;
    public float pushBack = 150;

    public float cooldownStart = 0.1f;
    public float chargeCooldownStart = 1f;
    private float cooldown1;
    private float cooldown2;
    private float cooldownShow;
    private float cooldownShowMult = 0.2f;

    void Start()
    {
        cooldown1 = cooldownStart;
        cooldown2 = 0;
    }

    void Update()
    {
        // places bullet in front of player nose only when both conditions met
        if (Input.GetKey(GameManagerAltered.Instance.script.keyShoot1) && cooldown1 <= 0 && !rush.rushState) 
        {
            deployDistance = transform.TransformPoint(0, 0, dropOffset);
            DoShoot(-bulletOffset);
            DoShoot(bulletOffset);
            DoShoot(0);
            cooldown1 = cooldownStart;
        }
        else
        {
            cooldown1 -= Time.deltaTime;
        }

        if (Input.GetKey(GameManagerAltered.Instance.script.keyShoot2) && cooldown2 <= 0 && !rush.rushState)
        {
            deployDistance = transform.TransformPoint(0, 0, dropOffset);
            DoShootBig();
            cooldown2 = chargeCooldownStart;
        }
        else
        {
            // slightly darkens the spaceship sprite when on cooldown
            cooldownShow = 1 - cooldownShowMult * cooldown2;
            cooldown2 -= Time.deltaTime;
            cooldownEffect.color = new Color(cooldownShow, cooldownShow, cooldownShow, 1);
        }
    }

    private void DoShoot(int rotation)
    {
        // creates a bullet and then gives that bullet velocity and rotation based on the player's rotation and a given offset
        GameObject bulletInstance = Instantiate(bulletPrefab, deployDistance, transform.rotation);
        bulletInstance.gameObject.transform.Rotate(0, bulletRotationMult * rotation, 0);
        bulletInstance.GetComponent<Rigidbody>().AddRelativeForce(rotation, 0, bulletSpeed);
        AudioManagerAltered.Instance.PlayRandomClip(randomBulletSound, 0.5f);
    }

    private void DoShootBig()
    {
        // creates a bulltet and then gives that bullet velocity  and rotation based on the player's rotation
        GameObject bulletInstance = Instantiate(bulletPrefabBig, deployDistance, transform.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddRelativeForce(0, 0, bulletSpeedMult * bulletSpeed);
        AudioManagerAltered.Instance.PlayClip(simpleBullet, 1.5f);

        // gives the player recoil
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.linearVelocity *= 0.25f;
        rb.angularVelocity *= 0.25f;
        rb.AddRelativeForce(0, 0, -pushBack);
    }
}
