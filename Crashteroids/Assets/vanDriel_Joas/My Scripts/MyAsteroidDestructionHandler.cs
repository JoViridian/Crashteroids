using UnityEngine;

public class MyAsteroidDestructionHandler : MonoBehaviour
{
    public GameObject prefab;
    public int splitAmount = 3;
    private int spawnHelp = 120;
    private float speedTotal = 1000f;
    private float dropOffset = 0.5f;

    public void SplitMiniSpawn()
    {
        GameManagerAltered.Instance.asteroidTotal.Remove(gameObject);

        for (int i = 0; i < splitAmount; i++)
        {
            // rotates the GO and then takes that new rotation to spawn the new GOs with perfect seperation
            gameObject.transform.Rotate(0, spawnHelp, 0);
            GameObject prefabInstance = Instantiate(prefab, transform.TransformPoint(0, 0, dropOffset), transform.rotation);
            prefabInstance.GetComponent<Rigidbody>().AddRelativeForce(0, 0, speedTotal);
        }
    }

    public void PowerUpSpawn()
    {
        GameManagerAltered.Instance.asteroidTotal.Remove(gameObject);
        GameObject prefabInstance = Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
