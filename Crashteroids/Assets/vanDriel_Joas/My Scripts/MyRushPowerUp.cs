using UnityEngine;
using UnityEngine.Rendering;

public class MyRushPowerUp : MonoBehaviour
{
    public bool rushState;
    public float rushDuration;
    private float rushTimer;
    public Rigidbody rocket;
    public int forwardPower = 360;
    public GameObject snowEffect;

    public SphereCollider drillPart;
    public SpriteRenderer shipLeftObject;
    public SpriteRenderer shipRightObject;
    public SpriteRenderer shipTopObject;
    public MyDamagePower damagePower;
    public LimitRigidbodyVelocity speedLimit;

    public PhysicsMaterial bounceBoosted;
    public Sprite shipLeftBoosted;
    public Sprite shipRightBoosted;
    public Sprite shipTopBoosted;
    public int damagePowerBoosted;
    public float speedLimitBoosted;

    private PhysicsMaterial bounceBase;
    private Sprite shipLeftBase;
    private Sprite shipRightBase;
    private Sprite shipTopBase;
    private int damagePowerBase;
    private float speedLimitBase;

    void Awake()
    {
        rushState = false;
        rushTimer = rushDuration;
        bounceBase = drillPart.material;
        shipLeftBase = shipLeftObject.sprite;
        shipRightBase = shipRightObject.sprite;
        shipTopBase = shipTopObject.sprite;
        damagePowerBase = damagePower.damagePower;
        speedLimitBase = speedLimit.maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (rushState)
        {
            drillPart.material = bounceBoosted;
            shipLeftObject.sprite = shipLeftBoosted;
            shipRightObject.sprite = shipRightBoosted;
            shipTopObject.sprite = shipTopBoosted;
            damagePower.damagePower = damagePowerBoosted;
            damagePower.complexDamage = false;
            damagePower.hitAble = 0;
            speedLimit.maxSpeed = speedLimitBoosted;
            rocket.mass = 100;
            RushTimer();
            Instantiate(snowEffect, transform.position, transform.rotation);
            rocket.AddRelativeForce(0, 0, forwardPower * Time.deltaTime, ForceMode.VelocityChange);
        }
        else
        {
            drillPart.material = bounceBase;
            shipLeftObject.sprite = shipLeftBase;
            shipRightObject.sprite = shipRightBase;
            shipTopObject.sprite = shipTopBase;
            damagePower.damagePower = damagePowerBase;
            damagePower.complexDamage = true;
            damagePower.hitAble = 1;
            speedLimit.maxSpeed = speedLimitBase;
            rocket.mass = 1;
        }
    }

    void RushTimer()
    {
        if (rushTimer < 0)
        {
            rushState = false;
            rushTimer = rushDuration;
        }
        else
        {
            rushTimer -= Time.deltaTime;
        }
    }
}
