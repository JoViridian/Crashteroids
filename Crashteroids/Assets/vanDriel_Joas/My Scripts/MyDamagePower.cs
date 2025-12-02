using UnityEngine;

public class DamagePower : MonoBehaviour
{
    public bool complexDamage = false;
    public int damagePower;
    private int damageTotal;
    private Vector3 velDiffThis;
    private Vector3 velDiffThat;
    private float velDiff;

    public int DoDamage(GameObject collision)
    {
        if (complexDamage == true)
        {
            // in a collision, gets the velocity difference between both GO and gives an appropriate damage value
            velDiffThis = gameObject.GetComponent<Rigidbody>().linearVelocity;
            velDiffThat = collision.GetComponent<Rigidbody>().linearVelocity;
            velDiff = Mathf.Abs(velDiffThis.x - velDiffThat.x) + Mathf.Abs(velDiffThis.z - velDiffThat.z);
            damageTotal = Mathf.RoundToInt(damagePower * velDiff) + 1;
        }
        else
        {
            damageTotal = damagePower;
        }

        return damageTotal;
    }
}
