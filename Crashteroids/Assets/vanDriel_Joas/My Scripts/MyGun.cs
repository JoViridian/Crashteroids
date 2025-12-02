using UnityEngine;

public class MyGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletPrefabBig;
    public AudioClip bulletSound1;
    public AudioClip bulletSound2;
    public AudioClip bulletSound3;
    private AudioClip[] randomBulletSound = new AudioClip[2];

    public Vector3 deployDistance;
    public float bulletSpeed = 300;
    public int bulletOffset = 60;
    public float cooldownStart = 0.1f;
    public float chargeCooldownStart = 1f;
    private float cooldown;
    private float cooldownShow;
    private float pushBack = 150;

    void Start()
    {
        cooldown = cooldownStart;
        randomBulletSound[0] = bulletSound1;
        randomBulletSound[1] = bulletSound2;
    }

    void Update()
    {
        // places bullet in front of player nose only when both conditions met
        if((Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Space)) && cooldown <= 0) 
        {
            deployDistance = transform.TransformPoint(0, 0, 0.5f);
            DoShoot(-bulletOffset);
            DoShoot(bulletOffset);
            DoShoot(0);
            cooldown = cooldownStart;
        }
        else
        {
            cooldown -= Time.deltaTime;
        }

        if ((Input.GetMouseButtonDown(1) || Input.GetKey(KeyCode.DownArrow)) && cooldown <= 0)
        {
            deployDistance = transform.TransformPoint(0, 0, 0.5f);
            DoShootBig();
            cooldown = chargeCooldownStart;
        }

        // slightly darkens the spaceship sprite when on cooldown
        cooldownShow = 1 - 0.2f * cooldown;
        transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color(cooldownShow, cooldownShow, cooldownShow, 1);
    }

    private void DoShoot(int rotation)
    {
        // creates a bullet and then gives that bullet velocity and rotation based on the player's rotation and a given offset
        GameObject bulletInstance = Instantiate(bulletPrefab, deployDistance, transform.rotation);
        bulletInstance.gameObject.transform.Rotate(0, 0.25f * rotation, 0);
        bulletInstance.GetComponent<Rigidbody>().AddRelativeForce(rotation, 0, bulletSpeed);
        AudioManager.Instance.PlayRandomClip(randomBulletSound);
    }

    private void DoShootBig()
    {
        // creates a bulltet and then gives that bullet velocity  and rotation based on the player's rotation
        GameObject bulletInstance = Instantiate(bulletPrefabBig, deployDistance, transform.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddRelativeForce(0, 0, 5 * bulletSpeed);
        AudioManager.Instance.PlayClip(bulletSound3);

        // gives the player recoil
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(0, 0, -pushBack);
    }
}
