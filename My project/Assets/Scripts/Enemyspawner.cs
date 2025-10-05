using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    [Header("Spawn Ayarları")]
    public float startSpawnInterval = 2f;   // Başlangıç aralığı (yavaş)
    public float minSpawnInterval = 0.4f;   // En hızlı olabileceği aralık
    public float difficultyGrowthRate = 0.05f; // Logaritmik büyüme oranı

    private float elapsedTime = 0f;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        Invoke(nameof(SpawnEnemy), 1f);
    }

    void SpawnEnemy()
    {
        // Viewport tabanlı rastgele pozisyon (tam ekrana yayılır)
        float randomXViewport = Random.Range(0f, 1f);
        Vector3 worldPos = cam.ViewportToWorldPoint(new Vector3(randomXViewport, 1.1f, cam.nearClipPlane));
        worldPos.z = 0f;

        Instantiate(enemyPrefab, worldPos, Quaternion.identity);

        // Geçen süreyi artır
        elapsedTime += Time.deltaTime + 1f;

        // 🧩 Logaritmik azalan spawn aralığı:
        // Başta yavaş, sonra kademeli hızlanır (log eğrisi)
        float newInterval = Mathf.Lerp(minSpawnInterval, startSpawnInterval,
            1f / Mathf.Log(elapsedTime * difficultyGrowthRate + 2f));

        Invoke(nameof(SpawnEnemy), newInterval);
    }
}
