using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // ← Bu satır çok önemli
    public float spawnInterval = 1.5f;
    public float xRange = 2.5f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-xRange, xRange);
        Vector2 spawnPos = new Vector2(randomX, 6f);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}

