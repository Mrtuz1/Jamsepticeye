using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // düþman prefab referansý
    public float spawnInterval = 2f; // kaç saniyede bir doðacak
    public float spawnRangeX = 8f; // x ekseninde rastgele doðma aralýðý
    public float spawnY = 6f; // ekranýn üst kýsmý

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
