using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float padding = 0.1f;

    public float minSpawnTime = 1;
    public float maxSpawnTime = 3;
    public float minSpawnTimeUpdate = 5;
    public float maxSpawnTimeUpdate = 10;
    public int maxAsteroidTotal = 3;
    private float timer;
    private float maxIncreaseTimer;
    public float maxIncreaseTimerReset = 30;
    public float maxAsteroidListSize = 5;

    void Start()
    {
        ResetTimer();
        maxIncreaseTimer = maxIncreaseTimerReset;
    }

    void Update()
    {
        // ! changed how timer works to not countdown whilst the maxAsteroidTotal has been reached
        // ! purposely kept the asteroidTotal list to only big asteroids
        if (GameManager.Instance.asteroidTotal.Count <= maxAsteroidTotal - 1)
        {
            DoTimer();
        }

        // ! added a system that increases the max total big asteroids over time
        // ! only sets the spawn timer higher  after a while to have a quicker early game
        if (maxIncreaseTimer < 0 && maxAsteroidTotal < maxAsteroidListSize)
        {
            maxAsteroidTotal++;
            maxIncreaseTimer = maxIncreaseTimerReset * 2;
            minSpawnTime = minSpawnTimeUpdate;
            maxSpawnTime = maxSpawnTimeUpdate;
        }
        else
        {
            maxIncreaseTimer -= Time.deltaTime;
        }
    }

    private void DoTimer()
    {
        if (timer <= 0)
        {
            Spawn();
            ResetTimer();
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    private void Spawn()
    {
        // instantiate new GO from prefab on position off screen
        GameObject asteroidInstance = Instantiate(asteroidPrefab, GetRandomPositionOffScreen(), Quaternion.identity, transform);
        GameManager.Instance.asteroidTotal.Add(asteroidInstance);
    }

    private void ResetTimer()
    {
        timer = Random.Range(minSpawnTime, maxSpawnTime);
    }

    private Vector3 GetRandomPositionOffScreen()
    {
        // randomly choose which side to spawn
        int side = Random.Range(0, 4);

        // ! removed pecentual padding to work with my screen loop
        float paddingWidth = padding;
        float paddingHeight = padding;

        // define position vector in screen space
        Vector3 screenPosition = Vector3.zero;

        switch (side)
        {
            case 0: // top
                screenPosition = new Vector3(Random.Range(-paddingWidth, Screen.width + paddingWidth), Screen.height + paddingHeight);
                break;

            case 1: // right
                screenPosition = new Vector3(Screen.width + paddingWidth, Random.Range(-paddingHeight, Screen.height + paddingHeight));
                break;

            case 2: // bottom
                screenPosition = new Vector3(Random.Range(-paddingWidth, Screen.width + paddingWidth), -paddingHeight);
                break;

            case 3: // left
                screenPosition = new Vector3(-paddingWidth, Random.Range(-paddingHeight, Screen.height + paddingHeight));
                break;
        }

        // convert from view port space to world space
        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        spawnPosition.y = 0;
        return spawnPosition;
    }
}
