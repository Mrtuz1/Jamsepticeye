using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // d��man prefab referans�
    public float spawnInterval = 2f; // ka� saniyede bir do�acak
    public float spawnRangeX = 8f; // x ekseninde rastgele do�ma aral���
    public float spawnY = 6f; // ekran�n �st k�sm�

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnY, 0);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
