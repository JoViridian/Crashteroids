using UnityEngine;

public class MyCrashout : MonoBehaviour
{
    public MyDamagePower power;
    public float armorCutoff = 0.2f;
    private float damageDecrease = 0.2f;

    // ! make this code cleaner later, look into unity events
    private void OnCollisionEnter(Collision collision)
    {
        if (power.defenseTotal > armorCutoff)
        {
            power.defenseTotal -= damageDecrease;
        }
    }

    void Update()
    {
        if (power.defenseTotal < 1)
        {
            power.defenseTotal += (0.2f * Time.deltaTime);
        }
    }
}
