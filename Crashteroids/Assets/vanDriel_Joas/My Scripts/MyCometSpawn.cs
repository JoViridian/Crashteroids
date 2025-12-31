using UnityEngine;

public class MyCometSpawn : MonoBehaviour
{
    public AsteroidSpawnerAltered scriptbase;
    public GameObject cometPrefab;
    public float spawnDelayLow;
    public float spawnDelayHigh;
    public float spawnChance;
    private bool spawnAllow;
    private float spawnTimer;

    private void Awake()
    {
        spawnTimer = Random.Range(spawnDelayLow, spawnDelayHigh);
        spawnAllow = false;
    }

    void Update()
    { 
        if (!spawnAllow && GameManagerAltered.Instance.cometOpportunity > spawnChance)
        {
            spawnAllow = true;
            GameManagerAltered.Instance.cometOpportunity = 0;
        }

        if (spawnAllow)
        {
            if (spawnTimer <= 0)
            {
                scriptbase.Spawn(cometPrefab);
                spawnAllow = false;
                spawnTimer = Random.Range(spawnDelayLow, spawnDelayHigh);
            }
            else
            {
                spawnTimer -= Time.deltaTime;
            }
        }
            
    }
}
