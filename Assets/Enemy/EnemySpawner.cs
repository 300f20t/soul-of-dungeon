using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 3f;
    public float spawnRange = 5f;

    private float spawnTimer;

    private void Start()
    {
        spawnTimer = spawnInterval;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            SpawnEnemy();
            spawnTimer = spawnInterval;
        }
    }

    private void SpawnEnemy()
    {
        Vector2 randomSpawnPoint = (Vector2)transform.position + Random.insideUnitCircle * spawnRange;
        GameObject enemyClone = Instantiate(enemyPrefab, randomSpawnPoint, Quaternion.identity);
        enemyClone.SetActive(true);
    }
}
