using UnityEngine;

public class MyGun : MonoBehaviour
{
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
    private float pushBack = 150;

    public float cooldownStart = 0.1f;
    public float chargeCooldownStart = 1f;
    private float cooldown;
    private float cooldownShow;
    private float cooldownShowMult = 0.2f;

    void Start()
    {
        cooldown = cooldownStart;
    }

    void Update()
    {
        // places bullet in front of player nose only when both conditions met
        if((Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Space)) && cooldown <= 0) 
        {
            deployDistance = transform.TransformPoint(0, 0, dropOffset);
            DoShoot(-bulletOffset);
            DoShoot(bulletOffset);
            DoShoot(0);
            cooldown = cooldownStart;
        }
        else
        {
            // slightly darkens the spaceship sprite when on cooldown
            cooldownShow = 1 - cooldownShowMult * cooldown;
            cooldown -= Time.deltaTime;
            cooldownEffect.color = new Color(cooldownShow, cooldownShow, cooldownShow, 1);
        }

        if ((Input.GetMouseButtonDown(1) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && cooldown <= 0)
        {
            deployDistance = transform.TransformPoint(0, 0, dropOffset);
            DoShootBig();
            cooldown = chargeCooldownStart;
        }
    }

    private void DoShoot(int rotation)
    {
        // creates a bullet and then gives that bullet velocity and rotation based on the player's rotation and a given offset
        GameObject bulletInstance = Instantiate(bulletPrefab, deployDistance, transform.rotation);
        bulletInstance.gameObject.transform.Rotate(0, bulletRotationMult * rotation, 0);
        bulletInstance.GetComponent<Rigidbody>().AddRelativeForce(rotation, 0, bulletSpeed);
        AudioManager.Instance.PlayRandomClip(randomBulletSound);
    }

    private void DoShootBig()
    {
        // creates a bulltet and then gives that bullet velocity  and rotation based on the player's rotation
        GameObject bulletInstance = Instantiate(bulletPrefabBig, deployDistance, transform.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddRelativeForce(0, 0, bulletSpeedMult * bulletSpeed);
        AudioManager.Instance.PlayClip(simpleBullet);

        // gives the player recoil
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(0, 0, -pushBack);
    }
}
