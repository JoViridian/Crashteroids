using UnityEngine;

public class MyDamagePower : MonoBehaviour
{
    public bool complexDamage = false;
    public int damagePower;
    private int damageTotal;
    private Vector3 velDiffThis;
    private Vector3 velDiffThat;
    private float velDiff;
    public float defenseTotal = 1;
    public int hitAble = 1;

    public int DoDamage(GameObject collision)
    {
        if (complexDamage)
        {
            // in a collision, gets the velocity difference between both GO and gives an appropriate damage value
            velDiffThis = gameObject.GetComponent<Rigidbody>().linearVelocity;
            velDiffThat = collision.GetComponent<Rigidbody>().linearVelocity;
            velDiff = Mathf.Abs((velDiffThis - velDiffThat).magnitude);
            MyDamagePower collisionscript = collision.GetComponent<MyDamagePower>();
            damageTotal = collisionscript.hitAble * (Mathf.RoundToInt(damagePower * velDiff * collisionscript.defenseTotal) + 1); // the 1 is added to prevent a 0 damage result
        }
        else
        {
            damageTotal = damagePower;
        }

        return damageTotal;
    }
}
